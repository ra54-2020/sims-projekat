using Individualan_projekat.Model;
using Individualan_projekat.ServiceInterfaces;
using Individualan_projekat.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for ReservationsForOwner.xaml
    /// </summary>
    public partial class ReservationsForOwner :Window, INotifyPropertyChanged
    {
        private Reservation _selectedReservation;
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IReservationService _reservationService;

        private readonly IApartmentService _apartmentService;
        public static ObservableCollection<Apartment> Apartments { get; set; }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Reservation SelectedReservation
        {
            get => _selectedReservation;
            set
            {
                if(value != _selectedReservation)
                {
                    _selectedReservation = value;
                }
            }
        }

        private ObservableCollection<Reservation> _reservations;
        public ObservableCollection<Reservation> Reservations
        {
            get => _reservations;
            set
            {
                _reservations = value;
            }
        }

        public ObservableCollection<String> Filters { get; set; }
        private String _selectedFilter;
        public String SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                _selectedFilter = value;
            }
        }

        public String _text;
        public String Text
        {
            get => _text;
            set
            {
                _text = value;

            }
        }

        public ReservationsForOwner()
        {
            InitializeComponent();
            this.DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _reservationService = InjectorService.CreateInstance<IReservationService>();
            _apartmentService = InjectorService.CreateInstance<IApartmentService>();


        Reservations = new ObservableCollection<Reservation>(_reservationService.GetAll().FindAll(r => r.Owner.Id == MainWindow.LogInUser.Id));

            Filters = new ObservableCollection<String>();
            Filters.Add("Waiting");
            Filters.Add("Approved");
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            List<Reservation> r = new List<Reservation>();
            if (SelectedFilter == "Waiting")
            {
                r = _reservationService.GetAll().Where(r =>  r.Owner.Id == MainWindow.LogInUser.Id && r.Status == Model.Enums.ReservationStatus.Waiting).ToList();
            }
            else
            {
                r = _reservationService.GetAll().Where(r => r.Owner.Id == MainWindow.LogInUser.Id && r.Status == Model.Enums.ReservationStatus.Approved).ToList();
            }
            Reservations.Clear();
            foreach (var res in r)
            {
                Reservations.Add(res);
            }
        }

        private void HotelClick(object sender, RoutedEventArgs e)
        {
            List<Reservation> a = new List<Reservation>();

            a = _reservationService.GetAll().FindAll(ap => ap.Owner.Id == MainWindow.LogInUser.Id && ap.Apartment.Hotel.Name.ToLower().Contains(Text.ToLower()));

            Reservations.Clear();
            foreach(Reservation r in a)
            {
                Reservations.Add(r);
            }

        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            Reservations.Clear();
            foreach(Reservation r in _reservationService.GetAll().FindAll(r => r.Owner.Id == MainWindow.LogInUser.Id))
            {
                Reservations.Add(r);
            }
     
            OnPropertyChanged(nameof(Reservations));
            myTextBox.Text = "";
        }
    }
}
