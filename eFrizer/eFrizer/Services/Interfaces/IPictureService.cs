using eFrizer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services.Interfaces
{
    public interface IPictureService : ICRUDService<Model.Picture, object, Model.PictureInsertRequest, Model.PictureUpdateRequest>
    {
        Task<Byte[]> GetPictureStream(int imageId);
        Task<Gallery> GetPictureIds(int hairSalonId);
    }
}
