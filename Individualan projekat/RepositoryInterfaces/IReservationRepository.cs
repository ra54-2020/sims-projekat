using Individualan_projekat.Model;
using Individualan_projekat.Observer;

namespace Individualan_projekat.RepositoryInterfaces
{
    public interface IReservationRepository : IRepository<Reservation>, ISubject
    {
        void Create(Reservation reservation);
        void Save();
        void Delete(Reservation reservation);
        Reservation Update(Reservation reservation);
    }
}