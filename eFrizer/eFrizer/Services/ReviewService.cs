using AutoMapper;
using eFrizer.Database;
using eFrizer.Model.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class ReviewService : BaseCRUDService<Model.Review.Review, Database.Review, ReviewSearchRequest, ReviewInsertRequest, ReviewUpdateRequest> , IReviewService
    {
        public ReviewService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {
        }


        public override IEnumerable<Model.Review.Review> Get(ReviewSearchRequest search = null)
        {
            var entity = Context.Set<Database.HairDresser>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Text))
            {
                entity = entity.Where(x => x.Name.Contains(search.Text));
            }

            var list = entity.ToList();

            return _mapper.Map<List<Model.Review.Review>>(list);
        }
    }
}
