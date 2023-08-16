using Individualan_projekat.Model;
using Individualan_projekat.Observer;

namespace Individualan_projekat.ServiceInterfaces
{
    public interface IOwnerService : IService<Owner>
    {
        Owner GetByEmailAndPassword(string email, string password);
    }
}