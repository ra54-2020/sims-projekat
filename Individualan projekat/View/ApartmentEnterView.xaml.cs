using Individualan_projekat.Model;
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
using Individualan_projekat.ServiceInterfaces;
using Individualan_projekat.Util;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Individualan_projekat.View
{
    /// <summary>
    /// Interaction logic for ApartmentEnterView.xaml
    /// </summary>
    public partial class ApartmentEnterView : Window, INotifyPropertyChanged
    {
        public static ObservableCollection<String> Hotels { get; set; }
        private readonly IHotelService _hotelSerivece;
        private readonly IApartmentService _apartmentService;

        public Apartment SelectedApartment { get; set; }

        public ApartmentEnterView()
        {
            InitializeComponent();
            this.DataContext = this;

            _hotelSerivece = InjectorService.CreateInstance<IHotelService>();
            _apartmentService = InjectorService.CreateInstance<IApartmentService>();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            List<String> hotels = (List<string>)_hotelSerivece.GetAll().Where(r => r.OwnerId == MainWindow.LogInUser.Id).Select(h => h.Name).ToList();

            Hotels = new ObservableCollection<string>(hotels);
            Hotels.Clear();
            foreach(var h in hotels)
            {
                Hotels.Add(h);
            }
        }

        private string _nameA;
        public string NameA
        {
            get => _nameA;
            set
            {
                if(_nameA != value)
                {
                    value = _nameA;
                    OnPropertyChanged("NameA");
                }
            }
        }
        private string _roomNumber;
        public string RoomNumber
        {
            get => _roomNumber;
            set
            {
                if (_roomNumber != value)
                {
                    value = _roomNumber;
                    OnPropertyChanged("RoomNumber");
                }
            }
        }
        private string _maxGuestNumber;
        public string MaxGuestNumber
        {
            get => _maxGuestNumber;
            set
            {
                if (_maxGuestNumber != value)
                {
                    value = _maxGuestNumber;
                    OnPropertyChanged("MaxGuestNumber");
                }
            }
        }
        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                if(_description != value)
                {
                    value = _description;
                    OnPropertyChanged("Description");
                }
            }
        }
        public string SelectedHotel { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string this[string columnName]
        {
            get
            {

                if (columnName == "NameA")
                {
                    if (columnName == "NameA")
                    {
                        if (string.IsNullOrEmpty(NameA))
                        {
                            return "Field is empty";
                        }

                        if (!Regex.IsMatch(NameA, "^[a-zA-Z]+$"))
                        {
                            return "Only letters";
                        }
                    }
                }
                if (columnName == "RoomNumber")
                {
                    if (columnName == "RoomNumber")
                    {
                        if (string.IsNullOrEmpty(RoomNumber))
                        {
                            return "Field is empty";
                        }
                        if (!int.TryParse(RoomNumber, out int roomNumberValue))
                        {
                            return "Invalid input";
                        }

                        if (roomNumberValue < 1 || roomNumberValue > 100)
                        {
                            return "Number between 1 and 100.";
                        }
                    }
                }
                if (columnName == "MaxGuestNumber")
                {
                    if (columnName == "MaxGuestNumber")
                    {
                        if (string.IsNullOrEmpty(MaxGuestNumber))
                        {
                            return "Field is empty";
                        }
                        if (!int.TryParse(MaxGuestNumber, out int maxGuestNumberValue))
                        {
                            return "Invalid input";
                        }

                        if (maxGuestNumberValue < 1 || maxGuestNumberValue > 100)
                        {
                            return "Number between 1 and 100.";
                        }
                    }
                }

                if (columnName == "Description")
                {
                    if (columnName == "Description")
                    {
                        if (string.IsNullOrEmpty(Description))
                        {
                            return "Field is empty";
                        }
                        if (!Regex.IsMatch(Description, "^[a-zA-Z]+$"))
                        {
                            return "Only letters";
                        }
                    }
                }
                return null;
            }

        }
        private readonly string[] _validatedProperties = { "Code", "RoomNumber", "MaxGuestNumber", "Description" };

        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (this[property] != null)
                        return false;
                }

                return true;
            }
        }

        private void CreateAppartment(object sender, RoutedEventArgs e)
        {
            if (IsValid)
            {
                Apartment a = new Apartment();
                a.Name = NameA;
                a.RoomNumber = int.Parse(RoomNumber);
                a.MaxGuestNumber = int.Parse(MaxGuestNumber);
                a.Description = Description;
                a.Hotel = _hotelSerivece.GetAll().Find(h => h.Name == SelectedHotel);
                a.HotelId = a.Hotel.Id;
                _apartmentService.Create(a);

                HotelView.Apartments.Clear();
                foreach (var ap in _apartmentService.GetAll())
                {
                    HotelView.Apartments.Add(ap);
                }

                this.Close();

            }
        }
        

    }
}
