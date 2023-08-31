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

namespace Individualan_projekat.View
{
    /// <summary>
    /// Interaction logic for ApartmentEnterView.xaml
    /// </summary>
    public partial class ApartmentEnterView : Window
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

        public string NameA { get; set;  }
        public string RoomNumber { get; set; }
        public string MaxGuestNumber { get; set; }
        public string Description { get; set; }

        public string SelectedHotel { get; set; }

        private void CreateAppartment(object sender, RoutedEventArgs e)
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
