using eFrizer.Model;
using eFrizer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class ReviewController : BaseCRUDController<Model.Review, ReviewSearchRequest, ReviewInsertRequest, ReviewUpdateRequest>
    {
        private readonly IReviewService service;

        public ReviewController(IReviewService service) : base(service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        [HttpGet("/Average")]
        public async Task<double> Average([FromQuery] ReviewAverageRequest request)
        {
            return await service.Average(request.hairSalonId);
        }
    }
}
