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
        public ObservableCollection<Apartment> Apartments { get; set; }

        public ObservableCollection<String> Hotels { get; set; }
        public String SelectedHotel { get; set; }
        public User LoggedUser { get; set; }
        public HotelView(User user)
        {
            InitializeComponent();
            this.DataContext = this;

            _hotelService = InjectorService.CreateInstance<IHotelService>();
            _apartmentService = InjectorService.CreateInstance<IApartmentService>();

            Apartments = new ObservableCollection<Apartment>(_apartmentService.GetAll());

            Hotels = new ObservableCollection<String>();
            Hotels.Add("Code");
            Hotels.Add("Name");
            Hotels.Add("Construction year");
            Hotels.Add("Stars number");
            Hotels.Add("Apartments");

            LoggedUser = user;
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
                a = _apartmentService.GetAll().FindAll(ap => ap.Hotel.ConstructionYear == Convert.ToInt32(Text));
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
        }
    }
}
