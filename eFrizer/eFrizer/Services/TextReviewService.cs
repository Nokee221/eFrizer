using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using eFrizer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class TextReviewService : BaseCRUDService<Model.TextReview, Database.TextReview, TextReviewSearchRequest, TextReviewInsertRequest, object>, ITextReviewService
    {
        public TextReviewService(eFrizerContext context, IMapper mapper)
          : base(context, mapper)
        {
        }

        public async Task<List<Model.TextReview>> Get([FromBody] TextReviewSearchRequest search = null)
        {
            if (search.HairSalonId != 0 && search.ClientId != 0)
            {
                var list = await Context.TextReviews.Where(x => x.HairSalonId == search.HairSalonId).Where(x => x.ClientId == search.ClientId).Include(x => x.HairSalon).Include(x => x.Client).ToListAsync();
                return _mapper.Map<List<Model.TextReview>>(list);
            }
            else if (search.HairSalonId != 0)
            {
                var list = await Context.TextReviews.Where(x => x.HairSalonId == search.HairSalonId).Include(x => x.HairSalon).Include(x => x.Client).ToListAsync();
                return _mapper.Map<List<Model.TextReview>>(list);
            }
            else
            {

                var list = await Context.TextReviews.ToListAsync();
                return _mapper.Map<List<Model.TextReview>>(list);
            }
        
        }
    }
}
