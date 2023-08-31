using Individualan_projekat.Model;
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
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IHotelRepository _hotelRepository;
        public ApartmentService()
        {
            _apartmentRepository = ApartmentRepository.GetInsatnce();
            _hotelRepository = HotelRepository.GetInsatnce();
            BindHotel();
        }

        public void BindHotel()
        {
            foreach(var a in GetAll())
            {
                Hotel h = _hotelRepository.Get(a.HotelId);
                a.Hotel = h;
                h.Apartments.Add(a.Id, a);
            }
        }
        public Apartment Get(int id)
        {
            return _apartmentRepository.Get(id);
        }
        public List<Apartment> GetAll()
        {
            return _apartmentRepository.GetAll();
        }
        public void Create(Apartment entity)
        {
            _apartmentRepository.Create(entity);
        }
        public void Delete(Apartment entity)
        {
            _apartmentRepository.Delete(entity);
        }
        public Apartment Update(Apartment entity)
        {
            return _apartmentRepository.Update(entity);
        }
        public void Save()
        {
            _apartmentRepository.Save();
        }
        void IService<Apartment>.Update(Apartment entity)
        {
            throw new NotImplementedException();
        }

    }
}
