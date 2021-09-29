using eFrizer.Model;
using eFrizer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class ReviewController : BaseCRUDController<Model.Review, ReviewSearchRequest, ReviewInsertRequest, ReviewUpdateRequest>
    {
        public ReviewController(IReviewService service) : base(service)
        {

        }
    }
}
