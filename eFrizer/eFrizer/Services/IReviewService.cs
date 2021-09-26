using eFrizer.Model.HairDresser;
using eFrizer.Model.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public interface IReviewService : ICRUDService<Model.Review.Review, ReviewSearchRequest, ReviewInsertRequest, ReviewUpdateRequest>
    {

    }
}
