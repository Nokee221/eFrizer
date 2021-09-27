using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class HairSalonPictureService : BaseCRUDService<Model.HairSalonPicture, Database.HairSalonPicture, object, HairSalonPictureInsertRequest, HairSalonPictureUpdateRequest>, IHairSalonPictureService
    {
        public HairSalonPictureService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<Model.HairSalonPicture> Update(int id1, int id2, HairSalonPictureUpdateRequest request)
        {
            var set = Context.Set<Database.HairSalonPicture>();
            var entity = set.Find(id1, id2);
            //TODO: I believe that this method should allow only for the picture to be changed since it might allow anyone to modify 
            //pictures for any given hairsalon. This might not be true if the method is never exposed to any client apps.
            var newEntity = new Database.HairSalonPicture()
            {
                PictureId = request.PictureId,
                HairSalonId = request.HairSalonId
            };
            Context.Remove(entity);
            Context.Add(newEntity);
            await Context.SaveChangesAsync();
            return _mapper.Map<Model.HairSalonPicture>(newEntity);
        }

        public async Task<Model.HairSalonPicture> Insert(HairSalonPictureInsertRequest request)
        {
            var entity = new Database.HairSalonPicture()
            {
                HairSalonId = request.HairSalonId,
                PictureId = request.PictureId
            };

            Context.Add(entity);

            await Context.SaveChangesAsync();

            return _mapper.Map<Model.HairSalonPicture>(entity);
        }
    }
}
