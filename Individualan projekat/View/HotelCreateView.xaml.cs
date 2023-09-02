using Individualan_projekat.Model;
using Individualan_projekat.ServiceInterfaces;
using Individualan_projekat.Util;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for HotelCreateView.xaml
    /// </summary>
    public partial class HotelCreateView : Window, INotifyPropertyChanged
    {
        private readonly IHotelService _hotelService;
        public HotelCreateView()
        {
            InitializeComponent();
            this.DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _hotelService = InjectorService.CreateInstance<IHotelService>();
        }

        private string _code;
        public string Code
        {
            get => _code;
            set
            {
                if(value != _code)
                {
                    _code = value;
                }
            }
        }
        private string _name;
        public string NameA
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                }
            }
        }
        private int _constructionYear;
        public int ConstructionYear
        {
            get => _constructionYear;
            set
            {
                if (value != _constructionYear)
                {
                    _constructionYear = value;
                }
            }
        }
        private int _starsNumber;
        public int StarsNumber
        {
            get => _starsNumber;
            set
            {
                if (value != _starsNumber)
                {
                    _starsNumber = value;
                }
            }
        }
        private string _ownerJmbg;
        public string OwnerJmbg
        {
            get => _ownerJmbg;
            set
            {
                if (value != _ownerJmbg)
                {
                    _ownerJmbg = value;

                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CreateHotel(object sender, RoutedEventArgs e)
        {
            Hotel h = new Hotel();
            h.Code = Code;
            h.Name = NameA;
            h.ConstructionYear = ConstructionYear;
            h.StarsNumber = StarsNumber;
            h.JmbgOwner = OwnerJmbg;
            h.Accepted = false;
            _hotelService.Create(h);
            MessageBox.Show("Your hotel has to be approved by the owner", "Hotel approval");
            this.Close();
        }
        
    }
}
