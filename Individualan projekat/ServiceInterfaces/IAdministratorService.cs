using Individualan_projekat.Model;

namespace Individualan_projekat.ServiceInterfaces
{
    public interface IAdministratorService : IService<Administrator>
    {
        Administrator GetByEmailAndPassword(string email, string password);
    }
}