using eFrizer.Model.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public interface IReservationService : ICRUDService<Model.Reservation.Reservation, ReservationSearchRequest, ReservationInsertRequest , ReservationUpdateRequest>
    {
    }
}
