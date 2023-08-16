using Individualan_projekat.Repository;
using Individualan_projekat.RepositoryInterfaces;
using Individualan_projekat.Service;
using Individualan_projekat.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individualan_projekat.Util
{
    public class InjectorService
    {
        private static Dictionary<Type, object> _implementations = new Dictionary<Type, object>
        {
            {typeof(IOwnerService), new OwnerService() },
            {typeof(IAdministratorService), new AdministratorService() },
            {typeof(IApartmentService), new ApartmentService() },
            {typeof(IGuestService), new GuestService() },
            {typeof(IHotelService), new HotelService() },
            {typeof(IReservationService), new ReservationService() }
        };
        public static T CreateInstance<T>()
        {
            Type type = typeof(T);
            if (_implementations.ContainsKey(type))
            {
                return (T)_implementations[type];
            }
            throw new ArgumentException($"No implementation found for type {type}");
        }
    }
}

