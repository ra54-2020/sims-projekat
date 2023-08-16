using System.Collections.Generic;

namespace Individualan_projekat.ServiceInterfaces
{
    public interface IService<T>
    {
        void Save();
        void Update(T entity);
        List<T> GetAll();
        T Get(int id);
    }
}