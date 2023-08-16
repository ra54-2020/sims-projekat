using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individualan_projekat.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        public T Get(int id);

        public List<T> GetAll();
    }
}