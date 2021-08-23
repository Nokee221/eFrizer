using eFrizer.Model.HairDresser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public interface IHairDresserService : ICRUDService<HairDresser, HairDresserSearchRequest, HairDresserInsertRequest, HairDresserUpdateRequest>
    {
    }
}
