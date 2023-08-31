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
    public class GuestRepository : IGuestRepository
    {
        private const string _filePath = "../../../Data/Guest.csv";
        private readonly Serializer<Guest> _serializer;
        private List<IObserver> _observers;
        private List<Guest> _guests;
        private static IGuestRepository _instance = null;

        public static IGuestRepository GetInsatnce()
        {
            if (_instance == null)
            {
                _instance = new GuestRepository();
            }
            return _instance;
        }

        private GuestRepository()
        {
            _serializer = new Serializer<Guest>();
            _guests = new List<Guest>();
            _guests = _serializer.FromCSV(_filePath);
            _observers = new List<IObserver>();
        }

        public Guest Get(int id)
        {
            return _guests.Find(o => o.Id == id);
        }

        public List<Guest> GetAll()
        {
            return _guests;
        }
        public void Save()
        {
            _serializer.ToCSV(_filePath, _guests);
        }
        public Guest Update(Guest entity)
        {
            Guest oldEntity = Get(entity.Id);
            if (oldEntity == null)
            {
                return null;
            }
            oldEntity = entity;
            Save();
            return oldEntity;
        }
    }
}
