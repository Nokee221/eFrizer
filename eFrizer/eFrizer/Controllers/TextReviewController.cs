using eFrizer.Model;
using eFrizer.Services;
using eFrizer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class TextReviewController : BaseCRUDController<Model.TextReview, TextReviewSearchRequest, TextReviewInsertRequest, object>
    {

        public TextReviewController(ITextReviewService service) : base(service)
        {
        }
    }
}
