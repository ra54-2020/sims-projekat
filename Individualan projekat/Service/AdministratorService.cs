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
    public class AdministratorService : IAdministratorService
    {
        private readonly IAdministratorRepository _administratorRepository;
        public AdministratorService()
        {
            _administratorRepository = AdministratorRepository.GetInsatnce();
        }
        public Administrator Get(int id)
        {
            return _administratorRepository.Get(id);
        }
        public List<Administrator> GetAll()
        {
            return _administratorRepository.GetAll();
        }
        public Administrator Update(Administrator entity)
        {
            return _administratorRepository.Update(entity);
        }
        public void Save()
        {
            _administratorRepository.Save();
        }
        public Administrator GetByEmailAndPassword(string email, string password)
        {
            return GetAll().Find(o => o.Email.Equals(email) && o.Password.Equals(password));
        }
        void IService<Administrator>.Update(Administrator entity)
        {
            throw new NotImplementedException();
        }
    }
}
