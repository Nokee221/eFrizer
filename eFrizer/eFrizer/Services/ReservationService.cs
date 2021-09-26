using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
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


        public override IEnumerable<Model.Reservation> Get(ReservationSearchRequest search = null)
        {
            var entity = Context.Set<Database.Reservation>().AsQueryable();

            //if (!string.IsNullOrWhiteSpace(search?.Name))
            //{
            //    entity = entity.Where(x => x.Name.Contains(search.Name));
            //}

            var list = entity.ToList();

            return _mapper.Map<List<Model.Reservation>>(list);
        }
    }
};
