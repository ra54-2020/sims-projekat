using Individualan_projekat.Model;

namespace Individualan_projekat.ServiceInterfaces
{
    public interface IGuestService : IService<Guest>
    {
        Guest GetByEmailAndPassword(string email, string password);
    }
}