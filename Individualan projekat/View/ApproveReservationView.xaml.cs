using Individualan_projekat.Model;
using Individualan_projekat.ServiceInterfaces;
using Individualan_projekat.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Individualan_projekat.View
{
    /// <summary>
    /// Interaction logic for ApproveReservationView.xaml
    /// </summary>
    public partial class ApproveReservationView : Window
    {
        public Reservation SelectedReservation { get; set; }
        
        private readonly IReservationService _reservationService;
        public ApproveReservationView(Reservation r)
        {
            InitializeComponent();
            this.DataContext = this;

            SelectedReservation = r;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _reservationService = InjectorService.CreateInstance<IReservationService>();

        }
        public void Update()
        {
            ReservationsForOwner.Reservations.Clear();
            foreach (Reservation r in _reservationService.GetAll().FindAll(r => r.Owner.Id == MainWindow.LogInUser.Id))
            {
                ReservationsForOwner.Reservations.Add(r);
            }
        }

        private void ApproveReservation(object sender, RoutedEventArgs e)
        {
            SelectedReservation.Status = Model.Enums.ReservationStatus.Approved;
            _reservationService.Update(SelectedReservation);
            Update();


            this.Close();
        }


        private void RejectReservation(object sender, RoutedEventArgs e)
        {
            SelectedReservation.Status = Model.Enums.ReservationStatus.Rejected;
            SelectedReservation.Comment = "The apartment is available on this application, so the guest could make a reservation, but someone made an appointment for the same apartment over the phone, and the owner still cannot confirm the reservation.";
            _reservationService.Update(SelectedReservation);
            Update();

            this.Close();
        }
    }
}
