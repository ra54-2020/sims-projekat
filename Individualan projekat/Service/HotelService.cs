using Individualan_projekat.Model;
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
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IOwnerRepository _ownerRepository;
        public HotelService()
        {
            _hotelRepository = HotelRepository.GetInsatnce();
            _ownerRepository = OwnerRepository.GetInsatnce();
            BindOwner();
        }

        private void BindOwner()
        {
            foreach(var r in GetAll())
            {
                r.Owner = _ownerRepository.Get(r.OwnerId);
            }
        }

        public Hotel Get(int id)
        {
            return _hotelRepository.Get(id);
        }
        public List<Hotel> GetAll()
        {
            return _hotelRepository.GetAll();
        }
        public Hotel Update(Hotel entity)
        {
            return _hotelRepository.Update(entity);
        }
        public void Save()
        {
            _hotelRepository.Save();
        }

        public void Create(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public List<Apartment> GetAllApartments()
        {
            throw new NotImplementedException();
        }
    }
}
