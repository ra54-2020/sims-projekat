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
    /// Interaction logic for ReservationShowView.xaml
    /// </summary>
    public partial class ReservationShowView : Window, INotifyPropertyChanged
    {
        private Reservation _selectedReservation;
        public event PropertyChangedEventHandler PropertyChanged;

        public Reservation SelectedReservation
        {
            get => _selectedReservation;
            set
            {
                _selectedReservation = value;
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
       
        private readonly IReservationService _reservationService;

        private string _selectedFilter;
        public string SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                _selectedFilter = value;
            }
        }

        public ReservationShowView()
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _reservationService = InjectorService.CreateInstance<IReservationService>();


            Reservations = new ObservableCollection<Reservation>(_reservationService.GetAll().FindAll(r => r.Guest.Id == MainWindow.LogInUser.Id));

            Filters = new ObservableCollection<String>();
            Filters.Add("Waiting");
            Filters.Add("Approved");
            Filters.Add("Rejected");
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            List<Reservation> r = new List<Reservation>();
            if(SelectedFilter == "Waiting")
            {
                r = _reservationService.GetAll().Where(r => r.Status == Model.Enums.ReservationStatus.Waiting).ToList();
            }
            else if(SelectedFilter == "Approved")
            {
                r = _reservationService.GetAll().Where(r => r.Status == Model.Enums.ReservationStatus.Approved).ToList();
            }
            else
            {
                r = _reservationService.GetAll().Where(r => r.Status == Model.Enums.ReservationStatus.Rejected).ToList();
            }
            Reservations.Clear();
            foreach (var res in r)
            {
                Reservations.Add(res);
            }

        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            if(SelectedReservation == null)
            {
                return;
            }
            SelectedReservation.Status = Model.Enums.ReservationStatus.Canceled;
            _reservationService.Update(SelectedReservation);
            Update();
        }

        public void Update()
        {
            Reservations.Clear();
            foreach(var r in _reservationService.GetAll().FindAll(r => r.Guest.Id == MainWindow.LogInUser.Id))
            {
                Reservations.Add(r);
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            Reservations.Clear();
            foreach (var r in _reservationService.GetAll())
            {
                Reservations.Add(r);
            }
            myComboBox.Text = "";
        }
    }
}
