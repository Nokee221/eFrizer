using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using Microsoft.AspNetCore.Mvc;
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


        public async Task<List<Model.Review>> Get([FromBody] ReviewSearchRequest search = null)
        {
            if (search.HairSalonId != 0)
            {
                var list = await Context.Reviews.Where(x => x.HairSalonId == search.HairSalonId).Include(x => x.HairSalon).Include(y => y.Client).ToListAsync();
                return _mapper.Map<List<Model.Review>>(list);
            }
            else if(search.HairSalonId != 0 && search.ClientId != 0)
            {
                var list = await Context.Reviews.Where(x => x.HairSalonId == search.HairSalonId).Where(y => y.ClientId == search.ClientId).Include(x => x.HairSalon).Include(y => y.Client).ToListAsync();
                return _mapper.Map<List<Model.Review>>(list);
            }
            else
            {

                var list = await Context.Reviews.ToListAsync();
                return _mapper.Map<List<Model.Review>>(list);
            }
        }

        public async Task<double> Average(int hairSalonId)
        {
            var entity = Context.Reviews.ToList();
            var temp = 0.0;
            var finalProsjek = 0.0;
            int brojac = 0;

            foreach (var item in entity)
            {
                if (item.HairSalonId == hairSalonId && item.StarRating != null)
                {
                    temp += item.StarRating;
                    brojac++;
                }
            }

            finalProsjek = temp / brojac;
            if (finalProsjek != null)
            {
                return finalProsjek;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
