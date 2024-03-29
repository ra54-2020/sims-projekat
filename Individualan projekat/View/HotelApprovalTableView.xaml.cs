﻿using Individualan_projekat.Model;
using Individualan_projekat.Service;
using Individualan_projekat.ServiceInterfaces;
using Individualan_projekat.Util;
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

        public static ObservableCollection<Hotel> Hotels { get; set; }
        private readonly IHotelService _hotelService;
        public HotelApprovalTableView()
        {
            InitializeComponent();
            this.DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            _hotelService = InjectorService.CreateInstance<IHotelService>();
            Hotels = new ObservableCollection<Hotel>(_hotelService.GetAll().FindAll(h => !h.Accepted && MainWindow.LogInUser.Jmbg == h.JmbgOwner));
            
        }

        private void OpenSelectedHotel(object sender, MouseButtonEventArgs e)
        {
            HotelApprovalView ha = new HotelApprovalView(SelectedHotel);
            ha.Show();
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            HotelView h = new HotelView(MainWindow.LogInUser);
            h.Show();
            this.Close();
        }
    }
}
