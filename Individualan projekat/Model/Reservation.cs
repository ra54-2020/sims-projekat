using Individualan_projekat.Model.Enums;
using Individualan_projekat.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individualan_projekat.Model
{
    public class Reservation: Individualan_projekat.Serializer.ISerializable
    {
        public int Id { get; set; }
        public int IdGuest { get; set; }
        public Guest Guest { get; set; }
        public int IdOwner { get; set; }
        public Owner Owner { get; set; }
        public Apartment Apartment { get; set; }
        public int IdApartment { get; set; }
        public DateTime StartDate { get; set; }
        public ReservationStatus Status { get; internal set; }
        public bool Deleted { get; set; }
        public Reservation()
        {
        }
        public Reservation(Guest guest, Owner owner, ReservationStatus status, Apartment apartment, DateTime startDate)
        {
            Status = status;
            IdGuest = guest.Id;
            this.Guest = guest;
            IdOwner = owner.Id;
            this.Owner = owner;
            IdApartment = apartment.Id;
            this.Apartment = apartment;
            this.StartDate = startDate;
        }
        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Status.ToString(),
                IdGuest.ToString(),
                IdApartment.ToString(),
                DateHelper.DateToString(StartDate),
                Deleted.ToString(),
                IdOwner.ToString()
            };
            return csvValues;
        }
        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Status = Enum.Parse<ReservationStatus>(values[1]);
            IdGuest = Convert.ToInt32(values[2]);
            IdApartment = Convert.ToInt32(values[3]);
            StartDate = DateHelper.StringToDate(values[4]);
            Deleted = Convert.ToBoolean(values[5]);
            IdOwner = Convert.ToInt32(values[6]);
        }
    }
}
