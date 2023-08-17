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
    /// Interaction logic for ReservationShowView.xaml
    /// </summary>
    public partial class ReservationShowView : Window
    {
        private String _selectedReservation;

        public String SelectedReservation
        {
            get => _selectedReservation;
            set
            {
                _selectedReservation = value;
            }
        }
        public ObservableCollection<Reservation> Reservations { get; set; }

        private readonly IReservationService _reservationService;

        public ReservationShowView()
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _reservationService = InjectorService.CreateInstance<IReservationService>();

            Reservations = new ObservableCollection<Reservation>(_reservationService.GetAll().FindAll(r => r.Guest.Id == MainWindow.LogInUser.Id));
        }
    }
}
