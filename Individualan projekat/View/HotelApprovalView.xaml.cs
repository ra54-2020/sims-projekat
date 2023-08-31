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
    /// Interaction logic for HotelApprovalView.xaml
    /// </summary>
    public partial class HotelApprovalView : Window
    {
        private readonly IHotelService _hotelService;
        
        public Hotel SelectedHotel { get; set; }
        public HotelApprovalView(Hotel hotel)
        {
            InitializeComponent();
            this.DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            SelectedHotel = hotel;
            _hotelService = InjectorService.CreateInstance<IHotelService>();
        }

        private void ApproveHotel(object sender, RoutedEventArgs e)
        {
            SelectedHotel.Accepted = true;
            _hotelService.Update(SelectedHotel);
            Close();
        }

        private void RejectHotel(object sender, RoutedEventArgs e)
        {
            _hotelService.Delete(SelectedHotel);
            Close();
        }
    }
}
