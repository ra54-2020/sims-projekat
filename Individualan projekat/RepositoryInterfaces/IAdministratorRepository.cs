using Individualan_projekat.Model;
using System.Collections.Generic;

namespace Individualan_projekat.RepositoryInterfaces
{
    public interface IAdministratorRepository
    {
  
        Administrator Get(int id);
        List<Administrator> GetAll();
        Administrator Update(Administrator entity);
        void Save();
    }
}