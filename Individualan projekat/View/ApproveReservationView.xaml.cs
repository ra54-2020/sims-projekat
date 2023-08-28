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
        public ObservableCollection<String> Apartments { get; set; }

        private String _selectedApartment;
        public String SelectedApartment
        {
            get => _selectedApartment;
            set
            {
                _selectedApartment = value;
            }
        }
        private readonly IApartmentService _apartmentService;
        public ApproveReservationView()
        {
            InitializeComponent();
            this.DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _apartmentService = InjectorService.CreateInstance<IApartmentService>();

        }

        private void ApproveReservation(object sender, RoutedEventArgs e)
        {
            ReservationsForOwner rfo = new ReservationsForOwner();
            rfo.Show();
            this.Close();
        }

        private void RejectReservation(object sender, RoutedEventArgs e)
        {
            RejectedReservationView rr = new RejectedReservationView();
            rr.Show();
            this.Close();
        }
    }
}
