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
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService()
        {
            _ownerRepository = OwnerRepository.GetInsatnce();
        }
        public void Save()
        {
            _ownerRepository.Save();
        }

        public Owner Get(int id)
        {
            return _ownerRepository.Get(id);
        }
        public List<Owner> GetAll()
        {
            return _ownerRepository.GetAll();
        }

        public Owner Update(Owner entity)
        {
            return _ownerRepository.Update(entity);
        }

        public Owner GetByEmailAndPassword(string email, string password)
        {
            return GetAll().Find(o => o.Email.Equals(email) && o.Password.Equals(password));
        }

        void IService<Owner>.Update(Owner entity)
        {
            _ownerRepository.Update(entity);
        }

        public void Create(Owner owner)
        {
            _ownerRepository.Create(owner);
        }
    }
}

