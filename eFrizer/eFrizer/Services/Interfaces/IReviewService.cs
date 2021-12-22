using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public interface IReviewService : ICRUDService<Model.Review, ReviewSearchRequest, ReviewInsertRequest, ReviewUpdateRequest>
    {
        Task<double> Average(int hairSalonId);
    }
}
