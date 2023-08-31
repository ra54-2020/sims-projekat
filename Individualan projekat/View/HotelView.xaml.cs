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
using Individualan_projekat.Service;

namespace Individualan_projekat.View
{
    /// <summary>
    /// Interaction logic for HotelView.xaml
    /// </summary>
    public partial class HotelView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IHotelService _hotelService;
        private readonly IApartmentService _apartmentService;
        public static ObservableCollection<Apartment> Apartments { get; set; }

        public ObservableCollection<String> Hotels { get; set; }

        private String _selectedHotel;
        public String SelectedHotel
        {
            get => _selectedHotel;
            set
            {
                _selectedHotel = value;
                if(_selectedHotel == "Apartments")
                {
                    ApartmentFilterCondition ac = new ApartmentFilterCondition();
                    ac.Show();
                }
            }
        }
       
            public User LoggedUser { get; set; }
        public HotelView(User user)
        {
            InitializeComponent();
            this.DataContext = this;

            _hotelService = InjectorService.CreateInstance<IHotelService>();
            _apartmentService = InjectorService.CreateInstance<IApartmentService>();

            Apartments = new ObservableCollection<Apartment>(_apartmentService.GetAll().Where(a => a.Hotel.Accepted));

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Hotels = new ObservableCollection<String>();
            Hotels.Add("Code");
            Hotels.Add("Name");
            Hotels.Add("Construction year");
            Hotels.Add("Stars number");
            Hotels.Add("Apartments");

            LoggedUser = user;

            if (LoggedUser is Owner)
            {
                ReservationButton.Visibility = Visibility.Visible;
                CreateApartmentButton.Visibility = Visibility.Visible;
                OwnerCreateButton.Visibility = Visibility.Collapsed;
            }
            else if(LoggedUser is Guest)
            {
                ReservationButton.Visibility = Visibility.Collapsed;
                CreateApartmentButton.Visibility = Visibility.Collapsed;
                OwnerCreateButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                ReservationButton.Visibility = Visibility.Collapsed;
                CreateApartmentButton.Visibility = Visibility.Collapsed;
                OwnerCreateButton.Visibility = Visibility.Visible;
            }
            OnPropertyChanged(nameof(Visibility));
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SortByStar(object sender, RoutedEventArgs e)
        {
            var a = _apartmentService.GetAll().OrderBy(ap => ap.Hotel.StarsNumber);
            Apartments.Clear();
            foreach(var ap in a)
            {
                Apartments.Add(ap);
            }
            OnPropertyChanged(nameof(Apartments));
        }

        private void SortByName(object sender, RoutedEventArgs e)
        {
            var a = _apartmentService.GetAll().OrderBy(ap => ap.Hotel.Name);
            Apartments.Clear();
            foreach(var ap in a)
            {
                Apartments.Add(ap);
            }
            OnPropertyChanged(nameof(Apartments));
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
        
        private void Filter(object sender, RoutedEventArgs e)
        {
            List<Apartment> a = new List<Apartment>();
            if(SelectedHotel == "Code")
            {
                a = _apartmentService.GetAll().FindAll(ap => ap.Hotel.Code.ToLower().Contains(Text.ToLower()));
            }
            else if(SelectedHotel == "Name")
            {
                a = _apartmentService.GetAll().FindAll(ap => ap.Hotel.Name.ToLower().Contains(Text.ToLower()));
            }
            else if(SelectedHotel == "Construction year")
            {
                a = _apartmentService.GetAll().FindAll(ap => ap.Hotel.ConstructionYear.ToString().ToLower().Contains(Text));
            }
            else if(SelectedHotel == "Stars number")
            {
                a = _apartmentService.GetAll().FindAll(ap => ap.Hotel.StarsNumber == Convert.ToInt32(Text));
            }
            else if(SelectedHotel == "Apartments")
            {
                ApartmentFilterCondition ac = new ApartmentFilterCondition();
                ac.Show();
            }
            Apartments.Clear();
            foreach (var ap in a)
            {
                Apartments.Add(ap);
            }
            OnPropertyChanged(nameof(Apartments));

        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            Apartments.Clear();
            foreach (var ap in _apartmentService.GetAll())
            {
                Apartments.Add(ap);
            }
            OnPropertyChanged(nameof(Apartments));
            myTextBox.Text = "";
        }

        private Apartment _selectedApartment;

        public Apartment SelectedApartment
        {
            get => _selectedApartment;
            set
            {
                _selectedApartment = value;
            }
        }

        private void ReservationApartment(object sender, MouseButtonEventArgs e)
        {
            
            if(LoggedUser is Guest)
            { 
                ReservationApartmentView rav = new ReservationApartmentView(SelectedApartment);
                rav.Show();
            }
        }

        private void ShowReservations(object sender, RoutedEventArgs e)
        {
            ReservationsForOwner rfo = new ReservationsForOwner();
            rfo.Show();
        }

        private void CreateApartment(object sender, RoutedEventArgs e)
        {
            ApartmentEnterView a = new ApartmentEnterView();
            a.Show();
        }

        private void AddOwner(object sender, RoutedEventArgs e)
        {
            OwnerCreateView o = new OwnerCreateView();
            o.Show();
        }

        private void SignOutButton(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                 "   Are you sure you want to log out?\n\n",
                 "Exit",
                 MessageBoxButton.YesNo);

            if(result == MessageBoxResult.Yes)
            {
                MainWindow m = new MainWindow();
                m.Show();
                this.Close();
            }
            else
            {
                return;
            }

        }

        private void AddHotel(object sender, RoutedEventArgs e)
        {
            HotelCreateView hc = new HotelCreateView();
            hc.Show();
        }
    }
}
