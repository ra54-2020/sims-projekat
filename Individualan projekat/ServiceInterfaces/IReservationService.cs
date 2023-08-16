using Individualan_projekat.Model;
using Individualan_projekat.Observer;
using System;
using System.Collections.Generic;

namespace Individualan_projekat.ServiceInterfaces
{
    public interface IReservationService : IService<Reservation>
    {
        void Create(Reservation entity);
        void Delete(Reservation entity);
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        bool IsDateInRange(Reservation reservation, DateTime date);
        DateTime CheckAvailableDate(int idAccommodation, DateTime startDate, DateTime endDate, int duration);
        List<Reservation> GetAheadReservationsForHotel(int idAccommodation);
        bool IsDateFree(int idAccommodation, DateTime date);
        Dictionary<DateTime, DateTime> GetAvailableDates(int idAccommodation, DateTime endDate, int duration);
        List<Reservation> GetGuestReservations(int id);
        List<Reservation> GetOwnerReservations(int id);
    }
}