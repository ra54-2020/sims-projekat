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
