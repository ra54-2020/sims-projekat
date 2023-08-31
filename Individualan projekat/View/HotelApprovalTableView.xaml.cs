using Individualan_projekat.Model;
using Individualan_projekat.ServiceInterfaces;
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

namespace Individualan_projekat.View
{
    /// <summary>
    /// Interaction logic for HotelApprovalTableView.xaml
    /// </summary>
    public partial class HotelApprovalTableView : Window
    { 
        public Hotel SelectedHotel { get; set; }

        public ObservableCollection<Hotel> Hotels { get; set; }
        private readonly IHotelService _hotelService;
        public HotelApprovalTableView()
        {
            InitializeComponent();
            this.DataContext = this;
        
            this.Hotels = new ObservableCollection<Hotel>(_hotelService.GetAll().FindAll(h => !h.Accepted && MainWindow.LogInUser.Jmbg == h.JmbgOwner));
            
        }

        private void OpenSelectedHotel(object sender, MouseButtonEventArgs e)
        {
            HotelApprovalView ha = new HotelApprovalView(SelectedHotel);
            ha.Show();
        }
    }
}
