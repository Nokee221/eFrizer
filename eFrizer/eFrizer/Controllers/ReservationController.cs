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
        public ReservationController(IReservationService service) : base(service)
        {

        }
    }
}
