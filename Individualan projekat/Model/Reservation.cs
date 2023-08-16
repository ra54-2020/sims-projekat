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
        public Hotel Hotel { get; set; }
        public int IdHotel { get; set; }
        public Apartment Apartment { get; set; }
        public int IdApartment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Deleted { get; set; }
        public ReservationStatus Status { get; internal set; }

        public Reservation()
        {
        }
        public Reservation(Guest guest, Owner owner, Hotel hotel, ReservationStatus status, Apartment apartment, DateTime startDate, DateTime endDate)
        {
            IdGuest = guest.Id;
            IdOwner = owner.Id;
            IdHotel = hotel.Id;
            EndDate = endDate;
            Status = status;
            this.Guest = guest;
            this.Owner = owner;
            this.Hotel = hotel;
            this.Apartment = apartment;
            IdApartment = apartment.Id;
            this.StartDate = startDate;
            Deleted = false;
        }
        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                DateHelper.DateToString(StartDate),
                DateHelper.DateToString(EndDate),
                IdGuest.ToString(),
                IdOwner.ToString(),
                IdHotel.ToString(),
                Deleted.ToString(),
                Status.ToString()
            };
            return csvValues;
        }
        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            StartDate = DateHelper.StringToDate(values[1]);
            EndDate = DateHelper.StringToDate(values[2]);
            IdGuest = Convert.ToInt32(values[3]);
            IdOwner = Convert.ToInt32(values[4]);
            IdHotel = Convert.ToInt32(values[5]);
            Deleted = Convert.ToBoolean(values[6]);
            Status = Enum.Parse<ReservationStatus>(values[7]);
        }
    }
}
