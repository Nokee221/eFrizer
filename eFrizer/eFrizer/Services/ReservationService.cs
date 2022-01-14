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
                var list = await Context.Reservations
                    .Where(x => x.HairDresserId == search.HairDresserId && x.To.Day == search.Day && x.To.Month == search.Month)
                    .Include(x => x.HairDresser)
                    .Include(x => x.HairSalonService).ThenInclude(x => x.Service)
                    .Include(x => x.Client)
                    .OrderBy(x => x.From)
                    .ToListAsync();
                return _mapper.Map<List<Model.Reservation>>(list);
            }
            else if(search.HairDresserId != null)
            {
                var list = await Context.Reservations
                    .Where(x => x.HairDresserId == search.HairDresserId)
                    .Include(x => x.HairDresser)
                    .Include(x => x.HairSalonService).ThenInclude(x => x.Service)
                    .Include(x => x.Client)
                    .OrderBy(x => x.From)
                    .ToListAsync();
                return _mapper.Map<List<Model.Reservation>>(list);
            }
            else if (search.ApplicationUserId != null)
            {
                var list = await Context.Reservations
                    .Where(x => x.ClientId == search.ApplicationUserId)
                    .Include(x => x.HairDresser)
                    .Include(x => x.HairSalonService).ThenInclude(x => x.Service)
                    .Include(x => x.Client)
                    .OrderBy(x => x.From)
                    .ToListAsync();
                return _mapper.Map<List<Model.Reservation>>(list);
            }
            else if (search.From != null && search.To != null)
            {
                var list = await Context.Reservations.Where(x => x.From >= search.From && x.To <= search.To && x.HairDresser.HairSalonId == search.HairSalonId)
                    .Include(x => x.Client)
                    .Include(x => x.HairSalonService).ThenInclude(x => x.Service)
                    .Include(x => x.HairDresser)
                    .OrderBy(x => x.From)
                    .OrderBy(x => x.From)
                    .ToListAsync();

                return _mapper.Map<List<Model.Reservation>>(list);
            }
            else if (search.HairSalonId != null)
            {
                var list = await Context.Reservations.Where(x => x.HairDresser.HairSalonId == search.HairSalonId)
                    .Include(x => x.Client)
                    .Include(x => x.HairSalonService).ThenInclude(x => x.Service)
                    .Include(x => x.HairDresser)
                    .OrderBy(x => x.From)
                    .ToListAsync();

                return _mapper.Map<List<Model.Reservation>>(list);
            }
            else
            {
                var list = await Context.Reservations.Include(x => x.HairSalonService)
                    .Include(x => x.HairDresser)
                    .Include(x => x.HairSalonService).ThenInclude(x => x.Service)
                    .Include(x => x.Client)
                    .OrderBy(x => x.From)
                    .ToListAsync();
                return _mapper.Map<List<Model.Reservation>>(list);

            }
        }

        public async override Task<Model.Reservation> Insert([FromBody] ReservationInsertRequest request)
        {

            Database.Reservation reservation = new Database.Reservation()
            {
                HairDresserId = request.HairDresserId,
                ClientId = request.ClientId,
                HairSalonServiceId = request.ServiceId,
                To = Convert.ToDateTime(request.To),
                From = Convert.ToDateTime(request.From),
            };

            Context.Reservations.Add(reservation);
            await Context.SaveChangesAsync();


            return _mapper.Map<Model.Reservation>(reservation);

            

        }


    }
};
