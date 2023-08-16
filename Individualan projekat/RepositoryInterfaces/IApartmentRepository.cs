using Individualan_projekat.Model;
using Individualan_projekat.Observer;

namespace Individualan_projekat.RepositoryInterfaces
{
    public interface IApartmentRepository : IRepository<Apartment>, ISubject
    {
      
        void Create(Apartment entity);
        void Delete(Apartment entity);
        Apartment Update(Apartment entity);
        void Save();
    }
}