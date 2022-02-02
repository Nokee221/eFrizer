using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public interface IHairSalonPictureService : ICRUDService<Model.HairSalonPicture, object, HairSalonPictureInsertRequest, HairSalonPictureUpdateRequest>
    {
        Task<HairSalonPicture> Update(int id1, int id2, HairSalonPictureUpdateRequest request);
        Task<HairSalonPicture> Insert(HairSalonPictureInsertRequest request);
    }
}
