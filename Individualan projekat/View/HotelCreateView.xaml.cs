using Individualan_projekat.Model;
using Individualan_projekat.ServiceInterfaces;
using Individualan_projekat.Util;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for HotelCreateView.xaml
    /// </summary>
    public partial class HotelCreateView : Window
    {
        private readonly IHotelService _hotelService;
        public HotelCreateView()
        {
            InitializeComponent();
            this.DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _hotelService = InjectorService.CreateInstance<IHotelService>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public int ConstructionYear { get; set; }
        public int StarsNumber { get; set; }
        public string OwnerJmbg { get; set; }

        private void CreateHotel(object sender, RoutedEventArgs e)
        {
            Hotel h = new Hotel();
            h.Code = Code;
            h.Name = Name;
            h.ConstructionYear = ConstructionYear;
            h.StarsNumber = StarsNumber;
            h.JmbgOwner = OwnerJmbg;
            h.Accepted = false;
            _hotelService.Create(h);

        }
    }
}
