using Individualan_projekat.Model;
using System.Collections.Generic;

namespace Individualan_projekat.RepositoryInterfaces
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        void Save();
        Owner Update(Owner entity);
    }
}