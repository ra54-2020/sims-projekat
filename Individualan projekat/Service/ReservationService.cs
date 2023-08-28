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
        private readonly IGuestRepository _guestRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IOwnerRepository _ownerRepository;
        public ReservationService()
        {
            _reservationRepository = ReservationRepository.GetInstance();
            _guestRepository = GuestRepository.GetInsatnce();
            _apartmentRepository = ApartmentRepository.GetInsatnce();
            _ownerRepository = OwnerRepository.GetInsatnce();
            BindGuest();
            BindApartment();
            BindOwner();
        }

        private void BindApartment()
        {
            foreach(var r in _reservationRepository.GetAll())
            {
                r.Apartment = _apartmentRepository.Get(r.IdApartment);
            }
        }

        private void BindOwner()
        {
            foreach(var r in _reservationRepository.GetAll())
            {
                r.Owner = _ownerRepository.Get(r.IdOwner);
            }
        }
        private void BindGuest()
        {
            foreach(var r in _reservationRepository.GetAll())
            {
                r.Guest = _guestRepository.Get(r.IdGuest);
            }
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
        public void Update(Reservation reservation)
        {
            _reservationRepository.Update(reservation);
        }
        public void Subscribe(IObserver observer)
        {
            _reservationRepository.Subscribe(observer);
        }
        public void Unsubscribe(IObserver observer)
        {
            _reservationRepository.Unsubscribe(observer);
        }

    }

}
