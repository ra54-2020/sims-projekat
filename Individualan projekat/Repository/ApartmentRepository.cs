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
    public class ApartmentRepository : IApartmentRepository
    {
        private const string _filePath = "../../../Data/Apartment.csv";
        private readonly Serializer<Apartment> _serializer;
        private readonly List<IObserver> _observers;
        private List<Apartment> _apartments;
        private static IApartmentRepository _instance = null;

        public static IApartmentRepository GetInsatnce()
        {
            if (_instance == null)
            {
                _instance = new ApartmentRepository();
            }
            return _instance;
        }

        private ApartmentRepository()
        {
            _serializer = new Serializer<Apartment>();
            _apartments = new List<Apartment>();
            _apartments = _serializer.FromCSV(_filePath);
            _observers = new List<IObserver>();

        }
        public Apartment Create(Apartment entity)
        {
            entity.Id = NextId();
            _apartments.Add(entity);
            Save();
            return entity;
        }
        public Apartment Delete(Apartment entity)
        {
            _apartments.Remove(entity);
            Save();
            return entity;
        }

        public Apartment Get(int id)
        {
            return _apartments.Find(a => a.Id == id);
        }
        public List<Apartment> GetAll()
        {
            return _apartments;
        }

        public int NextId()
        {
            if (_apartments.Count == 0) return 0;
            int newId = _apartments[_apartments.Count() - 1].Id + 1;
            foreach (Apartment a in _apartments)
            {
                if (newId == a.Id)
                {
                    newId++;
                }
            }
            return newId;
        }
        public void Save()
        {
            _serializer.ToCSV(_filePath, _apartments);
        }
        public Apartment Update(Apartment entity)
        {
            var oldEntity = Get(entity.Id);
            if (oldEntity == null)
            {
                return null;
            }
            oldEntity = entity;
            Save();
            return oldEntity;
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

        void IApartmentRepository.Create(Apartment entity)
        {
            throw new NotImplementedException();
        }

        void IApartmentRepository.Delete(Apartment entity)
        {
            throw new NotImplementedException();
        }
    }
}
