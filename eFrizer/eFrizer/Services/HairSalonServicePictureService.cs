using AutoMapper;
using eFrizer.Database;
using eFrizer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class HairSalonServicePictureService : BaseCRUDService<Model.HairSalonServicePicture, HairSalonServicePicture, object, Model.HairSalonServicePictureInsertRequest, Model.HairSalonServicePictureUpdateRequest>, IHairSalonServicePictureService
    {
        public HairSalonServicePictureService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {

        }

        public async override Task<List<Model.HairSalonServicePicture>> Get([FromBody] object search = null)
        {
            var entity = Context.Set<HairSalonServicePicture>();

            var list = await entity.Include(x => x.HairSalonService).ToListAsync();
            return _mapper.Map<List<Model.HairSalonServicePicture>>(list);
        }
    }
}
