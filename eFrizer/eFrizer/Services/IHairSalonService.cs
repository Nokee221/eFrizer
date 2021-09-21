using eFrizer.Model;
using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public interface IHairSalonService : ICRUDService<HairSalon, HairSalonSearchRequest, HairSalonInsertRequest, HairSalonUpdateRequest>
    {
    }
}
