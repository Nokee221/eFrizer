using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public interface IHairDresserService : ICRUDService<Model.HairDresser, HairDresserSearchRequest, HairDresserInsertRequest, HairDresserUpdateRequest>
    {
    }
}
