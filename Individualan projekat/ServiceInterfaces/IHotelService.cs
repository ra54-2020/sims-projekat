using Individualan_projekat.Model;
using Individualan_projekat.Observer;
using System;
using System.Collections.Generic;

namespace Individualan_projekat.ServiceInterfaces
{
    public interface IHotelService
    {
        List<Hotel> GetAll();
        void Create(Hotel hotel);
        List<Apartment> GetAllApartments();
    }
}