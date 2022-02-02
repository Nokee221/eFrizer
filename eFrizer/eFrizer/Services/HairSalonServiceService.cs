using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class HairSalonServiceService : BaseCRUDService<Model.HairSalonService, Database.HairSalonService, HairSalonServiceSearchRequest, HairSalonServiceInsertRequest, HairSalonServiceUpdateRequest>, IHairSalonServiceService
    {
        public HairSalonServiceService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {

        }

        public async override Task<Model.HairSalonService> Update(int id, [FromBody] HairSalonServiceUpdateRequest request)
        {
            var entity = Context.HairSalonServices.Include(x => x.Service).Where(x => x.HairSalonServiceId == id).First();
            
            _mapper.Map(request, entity);

            entity.Service.Name = request.Name;

            await Context.SaveChangesAsync();

            return _mapper.Map<Model.HairSalonService>(entity);
        }

        public async override Task<Model.HairSalonService> GetById(int id)
        {
            var set = Context.Set<HairSalonService>();
            var entity = await set.FindAsync(id);
            var model = _mapper.Map<Model.HairSalonService>(entity);
            model.ImageId = Context.HairSalonServicePictures.Where(x => x.HairSalonServiceId == id).First().PictureId;
            return model;
        }

        public async override Task<List<Model.HairSalonService>> Get([FromBody] HairSalonServiceSearchRequest search = null)
        {
            if (search.HairSalonId != 0)
            {
                var list = await Context.HairSalonServices.Where(x => x.HairSalonId == search.HairSalonId).Include(x => x.Service).ToListAsync();
                return _mapper.Map<List<Model.HairSalonService>>(list);
            }
            else
            {
                if (!string.IsNullOrEmpty(search?.Name))
                {
                    var list2 = await Context.HairSalonServices.Where(x => x.Service.Name == search.Name).Include(x => x.Service).ToListAsync();
                    return _mapper.Map<List<Model.HairSalonService>>(list2);
                }
                else
                {
                    var list = await Context.HairSalonServices.Include(x => x.Service).ToListAsync();
                    return _mapper.Map<List<Model.HairSalonService>>(list);
                }
            }
        }


        public async override Task<Model.HairSalonService> Insert([FromBody] HairSalonServiceInsertRequest request)
        {
            var serviceRequest = new ServiceInsertRequest
            {
                Name = request.Name
            };

            var newService = _mapper.Map<Database.Service>(serviceRequest);
            Context.Services.Add(newService);

            await Context.SaveChangesAsync();

            var hairSalonService = new Database.HairSalonService()
            {
                HairSalonId = request.HairSalonId,
                ServiceId = newService.ServiceId,
                Description = request.Description,
                Price = request.Price,
                TimeMin = request.TimeMin
            };

            Context.HairSalonServices.Add(hairSalonService);
            await Context.SaveChangesAsync();

            return _mapper.Map<Model.HairSalonService>(hairSalonService);
        }
    }
}
