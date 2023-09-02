using Individualan_projekat.Model;
using Individualan_projekat.ServiceInterfaces;
using Individualan_projekat.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ApartmentFilterCondition.xaml
    /// </summary>
    public partial class ApartmentFilterCondition : Window, INotifyPropertyChanged
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
        public ApartmentFilterCondition()
        {
            InitializeComponent();
            this.DataContext = this;

            _apartmentService = InjectorService.CreateInstance<IApartmentService>();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Apartments = new ObservableCollection<String>();
            Apartments.Add("Room");
            Apartments.Add("People");
            Apartments.Add("Room and people");
        }

        private String _condition;
        public String Condition
        {
            get => _condition;
            set
            {
                _condition = value;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       
        private void Search(object sender, RoutedEventArgs e)
        {
            List<Apartment> apartments = new List<Apartment>();
            if(SelectedApartment == "Room")
            {
                apartments = _apartmentService.GetAll().FindAll(ap => ap.RoomNumber == Convert.ToInt32(Condition));
            }
            else if(SelectedApartment == "People")
            {
                apartments = _apartmentService.GetAll().FindAll(ap => ap.MaxGuestNumber == Convert.ToInt32(Condition));
            }
            else
            {
                String[] conditions = Condition.Split(' ');
                if (conditions[1] == "&")
                {
                    apartments = _apartmentService.GetAll().FindAll(a => a.RoomNumber == Convert.ToInt32(conditions[0]) && a.MaxGuestNumber == Convert.ToInt32(conditions[2]));
                }
                else
                {
                    apartments = _apartmentService.GetAll().FindAll(a => a.RoomNumber == Convert.ToInt32(conditions[0]) || a.MaxGuestNumber == Convert.ToInt32(conditions[2]));
                }
            }
            HotelView.Apartments.Clear();
            foreach (Apartment a in apartments)
            {
                HotelView.Apartments.Add(a);
            }
        }
    }
}
