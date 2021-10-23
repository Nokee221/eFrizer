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
    public class ReservationService : BaseCRUDService<Model.Reservation, Database.Reservation, ReservationSearchRequest, ReservationInsertRequest, ReservationUpdateRequest>, IReservationService
    {
        public ReservationService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {
        }


        public async override Task<List<Model.Reservation>> Get(ReservationSearchRequest search = null)
        {
            if(search.HairDresserId != null && search.Day != 0 && search.Month != 0)
            {
                var list = await Context.Reservations.Where(x => x.HairDresserId == search.HairDresserId && x.To.Day == search.Day && x.To.Month == search.Month).Include(x => x.HairDresser).Include(x => x.Service).Include(x => x.Client).ToListAsync();
                return _mapper.Map<List<Model.Reservation>>(list);
            }
            else if(search.HairDresserId != null)
            {
                var list = await Context.Reservations.Where(x => x.HairDresserId == search.HairDresserId).Include(x => x.HairDresser).Include(x => x.Service).Include(x => x.Client).ToListAsync();
                return _mapper.Map<List<Model.Reservation>>(list);
            }
            else
            {
                var list = await Context.Reservations.Include(x => x.HairDresser).Include(x => x.Service).Include(x => x.Client).ToListAsync();
                return _mapper.Map<List<Model.Reservation>>(list);

            }
        }

        
    }
};
