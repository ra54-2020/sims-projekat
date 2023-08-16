using Individualan_projekat.Model;
using Individualan_projekat.Model.Enums;
using Individualan_projekat.Observer;
using Individualan_projekat.Repository;
using Individualan_projekat.RepositoryInterfaces;
using Individualan_projekat.ServiceInterfaces;
using Individualan_projekat.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individualan_projekat.Service
    {
        public class ReservationService : IReservationService
        {
            private readonly IReservationRepository _reservationRepository;
            public ReservationService()
            {
                _reservationRepository = ReservationRepository.GetInstance();
            }
            public void Save()
            {
                _reservationRepository.Save();
            }
            public Reservation Get(int id)
            {
                return _reservationRepository.Get(id);
            }
            public List<Reservation> GetAll()
            {
                return _reservationRepository.GetAll();
            }
            public void Create(Reservation reservation)
            {
                _reservationRepository.Create(reservation);
            }
            public void Delete(Reservation reservation)
            {
                _reservationRepository.Delete(reservation);
            }
            public Reservation Update(Reservation reservation)
            {
                return _reservationRepository.Update(reservation);
            }
            public void Subscribe(IObserver observer)
            {
                _reservationRepository.Subscribe(observer);
            }
            public void Unsubscribe(IObserver observer)
            {
                _reservationRepository.Unsubscribe(observer);
            }
            public List<Reservation> GetGuestReservations(int id)
            {
                List<Reservation> list = _reservationRepository.GetAll().FindAll(r => r.IdGuest == id).ToList();
                if (list == null)
                {
                    return new List<Reservation>();
                }
                return list;
            }
            public List<Reservation> GetOwnerReservations(int id)
            {
                List<Reservation> list = _reservationRepository.GetAll().FindAll(r => r.IdGuest == id).ToList();
                if (list == null)
                {
                    return new List<Reservation>();
                }
                return list;
            }

        public bool IsDateInRange(Reservation reservation, DateTime date)
            {
                return date >= reservation.StartDate && date <= reservation.EndDate;
            }
            private DateTime CheckDateAvailability(Reservation r, DateTime startDate, DateTime endDate, int duration)
            {
                while ((endDate - startDate).Days >= duration)
                {
                    if (IsDateInRange(r, startDate))
                    {
                        startDate = r.EndDate.AddDays(1);
                    }
                    else if (IsDateInRange(r, startDate.AddDays(duration)))
                    {
                        startDate = r.EndDate.AddDays(1);
                    }
                    else
                    {
                       return startDate;
                    }
                }
                return endDate;
            }
            public DateTime CheckAvailableDate(int idHotel, DateTime startDate, DateTime endDate, int duration)
                {
                if (GetAheadReservationsForHotel(idHotel).Count == 0)
                {
                    return startDate;
                }
                foreach (Reservation r in GetAheadReservationsForHotel(idHotel))
                {
                    return CheckDateAvailability(r, startDate, endDate, duration);
                }
                return endDate;
            }
            public List<Reservation> GetAheadReservationsForHotel(int idHotel)
            {
                try
                {
                    return GetAll().Where(r => r.IdHotel == idHotel && (r.Status == Model.Enums.ReservationStatus.Waiting || r.Status == Model.Enums.ReservationStatus.Reserved)).ToList();
                }
                catch
                {
                    return new List<Reservation>();
                }
            }
            public bool IsDateFree(int idHotel, DateTime date)
            {
                bool retVal = true;
                foreach (Reservation r in GetAheadReservationsForHotel(idHotel))
                {
                    retVal = retVal && !IsDateInRange(r, date);
                }
                return retVal;
            }
            public Dictionary<DateTime, DateTime> GetAvailableDates(int idHotel, DateTime endDate, int duration)
            {
                Dictionary<DateTime, DateTime> availableDates = new Dictionary<DateTime, DateTime>();
                DateTime temp = endDate;
                for (int i = 0; i < 10; i++)
                {
                    endDate = temp.AddDays(duration);
                    if (IsDateFree(idHotel, endDate.AddDays(i)) && IsDateFree(idHotel, endDate.AddDays(duration)))
                    {
                        availableDates.Add(endDate.AddDays(i), temp.AddDays(i)); //contra bind
                    }
                }
                return availableDates;
            }

        void IService<Reservation>.Update(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public void NotifyObservers()
        {
            throw new NotImplementedException();
        }
    }

}
