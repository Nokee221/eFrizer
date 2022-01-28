using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services.Interfaces
{
    public interface ITextReviewService : ICRUDService<Model.TextReview, TextReviewSearchRequest, TextReviewInsertRequest, object>
    {

    }
}
