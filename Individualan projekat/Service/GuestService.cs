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
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;
        public GuestService()
        {
            _guestRepository = GuestRepository.GetInsatnce();
        }
        public Guest Get(int id)
        {
            return _guestRepository.Get(id);
        }
        public List<Guest> GetAll()
        {
            return _guestRepository.GetAll();
        }
        public Guest Update(Guest entity)
        {
            return _guestRepository.Update(entity);
        }
        public void Save()
        {
            _guestRepository.Save();
        }
        public Guest GetByEmailAndPassword(string email, string password)
        {
            return GetAll().Find(o => o.Email.Equals(email) && o.Password.Equals(password));
        }

        void IService<Guest>.Update(Guest entity)
        {
            _guestRepository.Update(entity);
        }
    }
}
