using Individualan_projekat.Model;
using Individualan_projekat.ServiceInterfaces;
using Individualan_projekat.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Individualan_projekat.View
{
    /// <summary>
    /// Interaction logic for AddReservation.xaml
    /// </summary>
    public partial class AddReservation : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IReservationService _reservationService;
        public Hotel Hotel { get; set; }
        public Apartment Apartment { get; set; }
        public Guest Guest { get; set; }
        public int GuestsNumber { get; set; }
        public DateTime StartDateConverted { get; set; }
        public DateTime EndDateConverted { get; set; }
        public AddReservation(Hotel hotel, Apartment apartment, Guest guest)
        {
            InitializeComponent();
            this.DataContext = this;

            _reservationService = InjectorService.CreateInstance<IReservationService>();

            bool slobodan;
            Hotel = hotel;
            Apartment = apartment;
            Guest = guest;
            StartlDay = DateTime.Now;
            EndDay = DateTime.Now;

        }

        public AddReservation(Apartment selectedApartment, Guest logInGuest)
        {
            this.selectedApartment = selectedApartment;
            this.logInGuest = logInGuest;
        }

        public AddReservation(Hotel selectedHotel, Guest logInGuest)
        {
            this.selectedHotel = selectedHotel;
            this.logInGuest = logInGuest;
        }

        private DateTime _startDay;
        public DateTime StartlDay
        {
            get => _startDay;
            set
            {
                if (_startDay != value)
                {
                    _startDay = value;
                }
            }
        }

        private DateTime _endDay;
        private Apartment selectedApartment;
        private Guest logInGuest;
        private Hotel selectedHotel;

        public DateTime EndDay
        {
            get => _endDay;
            set
            {
                if (_endDay != value)
                {
                    _endDay = value;
                }
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
