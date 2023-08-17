using Individualan_projekat.Model;
using Individualan_projekat.ServiceInterfaces;
using Individualan_projekat.Util;
using System;
using System.Windows;

namespace Individualan_projekat.View
{
    /// <summary>
    /// Interaction logic for ReservationApartmentView.xaml
    /// </summary>
    public partial class ReservationApartmentView : Window
    {
        private DateTime _startlDay;
        public DateTime StartlDay
        {
            get { return _startlDay; }
            set
            {
                _startlDay = value;
            }
        }

        public Apartment SelectedApartment { get; set; }
        private readonly IReservationService _reservationService;
        public ReservationApartmentView(Apartment a)
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            _reservationService = InjectorService.CreateInstance<IReservationService>();
            SelectedApartment = a;

        }

        private void MakeReservation(object sender, RoutedEventArgs e)
        {
            Reservation reservation = new Reservation();
            reservation.StartDate = StartlDay;
            reservation.Status = Model.Enums.ReservationStatus.Waiting;
            reservation.IdGuest = MainWindow.LogInUser.Id;
            reservation.Guest = (Guest)MainWindow.LogInUser;
            reservation.Apartment = SelectedApartment;
            reservation.IdApartment = SelectedApartment.Id;
            _reservationService.Create(reservation);
            string message = "Your reservation is being processed";
            MessageBox.Show(message);
            Close();
        }
    }
}
