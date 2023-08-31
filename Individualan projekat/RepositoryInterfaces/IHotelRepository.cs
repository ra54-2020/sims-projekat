using Individualan_projekat.Model;
using Individualan_projekat.Observer;

namespace Individualan_projekat.RepositoryInterfaces
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Hotel Update(Hotel entity);
        void Save();

        Hotel Delete(Hotel entity);
    }
}