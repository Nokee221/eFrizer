using eFrizer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public interface ICityService : ICRUDService<Model.City.City , Model.City.CitySearchRequest, Model.City.CityInsertRequest, Model.City.CityUpdateRequest>
    {
    }
}
