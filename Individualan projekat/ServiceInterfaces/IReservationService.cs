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
    }
}