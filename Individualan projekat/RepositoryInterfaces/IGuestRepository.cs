using Individualan_projekat.Model;
using System.Collections.Generic;

namespace Individualan_projekat.RepositoryInterfaces
{
    public interface IGuestRepository : IRepository<Guest>
    {
        Guest Update(Guest entity);
        void Save();
    }
}