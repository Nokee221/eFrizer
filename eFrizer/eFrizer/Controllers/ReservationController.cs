using eFrizer.Database;
using eFrizer.Model;
using eFrizer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class ReservationController : BaseCRUDController<Model.Reservation, ReservationSearchRequest, ReservationInsertRequest, ReservationUpdateRequest>
    {
        public readonly eFrizerContext _context;
        public ReservationController(eFrizerContext context , IReservationService service) : base(service)
        {
            _context = context;
        }

    }
}
