using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class ReviewService : BaseCRUDService<Model.Review, Database.Review, ReviewSearchRequest, ReviewInsertRequest, ReviewUpdateRequest> , IReviewService
    {
        public ReviewService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {
        }


        public async override Task<List<Model.Review>> Get(ReviewSearchRequest search = null)
        {
            var entity = Context.Set<Database.Review>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Text))
            {
                entity = entity.Where(x => x.Text.Contains(search.Text));
            }

            var list = await entity.ToListAsync();

            return _mapper.Map<List<Model.Review>>(list);
        }
    }
}
