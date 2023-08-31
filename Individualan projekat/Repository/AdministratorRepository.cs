using Individualan_projekat.Model;
using Individualan_projekat.Observer;
using Individualan_projekat.RepositoryInterfaces;
using Individualan_projekat.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individualan_projekat.Repository
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private const string _filePath = "../../../Data/Administrator.csv";

        private Serializer<Administrator> _serializer;


        private List<IObserver> _observers;
        private List<Administrator> _administrators;
        private static IAdministratorRepository _instance = null;

        public static IAdministratorRepository GetInsatnce()
        {
            if (_instance == null)
            {
                _instance = new AdministratorRepository();
            }
            return _instance;
        }

        private AdministratorRepository()
        {
            _serializer = new Serializer<Administrator>();
            _administrators = new List<Administrator>();
            _administrators = _serializer.FromCSV(_filePath);
            _observers = new List<IObserver>();

        }

        public Administrator GetApartmentById(int id)
        {
            return _administrators.Find(a => a.Id == id);
        }

        public List<Administrator> GetAll()
        {
            return _administrators;
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var o in _observers)
            {
                o.Update();
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Administrator Update(Administrator entity)
        {
            Administrator oldEntity = Get(entity.Id);
            if (oldEntity == null)
            {
                return null;
            }
            oldEntity = entity;
            Save();
            return oldEntity;
        }

        public Administrator Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}

