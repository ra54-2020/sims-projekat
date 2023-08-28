using Individualan_projekat.Model;
using Individualan_projekat.ServiceInterfaces;
using Individualan_projekat.Util;
using System;
using System.ComponentModel;
using System.Windows;

namespace Individualan_projekat.View
{
    /// <summary>
    /// Interaction logic for ReservationApartmentView.xaml
    /// </summary>
    public partial class ReservationApartmentView : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime _startlDay;
        public DateTime StartlDay
        {
            get { return _startlDay; }
            set
            {
                _startlDay = value;
                OnPropertyChanged(nameof(StartlDay));
            }
        }

        public Apartment SelectedApartment { get; set; }
        private readonly IReservationService _reservationService;
        public ReservationApartmentView(Apartment a)
        {
            InitializeComponent();
            StartlDay = DateTime.Now;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            _reservationService = InjectorService.CreateInstance<IReservationService>();
            SelectedApartment = a;

        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void MakeReservation(object sender, RoutedEventArgs e)
        {
            Reservation reservation = new Reservation();
            reservation.StartDate = StartDatePicker.SelectedDate.Value;
            reservation.Status = Model.Enums.ReservationStatus.Waiting;
            reservation.IdGuest = MainWindow.LogInUser.Id;
            reservation.Guest = (Guest)MainWindow.LogInUser;
            reservation.Apartment = SelectedApartment;
            reservation.IdApartment = SelectedApartment.Id;
            reservation.Owner = SelectedApartment.Hotel.Owner;
            reservation.IdOwner = SelectedApartment.Hotel.OwnerId;
            _reservationService.Create(reservation);
            
            Close();
            ReservationShowView rs = new ReservationShowView();
            rs.Show();
        }
    }
}
