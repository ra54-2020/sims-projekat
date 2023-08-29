using Individualan_projekat.Model;
using Individualan_projekat.Observer;

namespace Individualan_projekat.ServiceInterfaces
{
    public interface IApartmentService : IService<Apartment>
    {
        void Create(Apartment entity);
    }
}