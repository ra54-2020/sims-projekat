using Individualan_projekat.Model;
using Individualan_projekat.Repository;
using Individualan_projekat.ServiceInterfaces;
using Individualan_projekat.Util;
using Individualan_projekat.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Individualan_projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IOwnerService _ownerService;
        private readonly IGuestService _guestService;
        private readonly IAdministratorService _administratorService;

        public static User LogInUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        private int failureNumber = 0;
       
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            _ownerService = InjectorService.CreateInstance<IOwnerService>();
            _guestService = InjectorService.CreateInstance<IGuestService>();
            _administratorService = InjectorService.CreateInstance<IAdministratorService>();

        }
        private void HotelView(object sender, RoutedEventArgs e)
        {
            Guest guest = GuestRepository.GetInsatnce().Get(0);
            HotelView hotelView = new HotelView(guest);
            hotelView.Show();
        }
        private void ApartmentView(object sender, RoutedEventArgs e)
        {
            Guest guest = GuestRepository.GetInsatnce().Get(0);
        }
        private void LogIn(object sender, RoutedEventArgs e)
        {
            failureNumber++;
            Password = passwordBox.Password;

            LogInUser = _ownerService.GetByEmailAndPassword(Email, Password);
            if (LogInUser != null)
            {
                //OwnerAccountView ownerAccount = new OwnerAccountView(LogInUser);
                //ownerAccount.Show();
                HotelView view = new HotelView(LogInUser);
                view.Show();
                Close();
                return;
            }
            LogInUser = _guestService.GetByEmailAndPassword(Email, Password);
            if (LogInUser != null)
            {
                //GuestAccount guestAccount = new GuestAccount(LogInUser);
                //guestAccount.Show();
                HotelView view = new HotelView(LogInUser);
                view.Show();
                Close();
                return;
            }
            LogInUser = _administratorService.GetByEmailAndPassword(Email, Password);
            if (LogInUser != null)
            {
                //AdministratorAccountView administratorAccount = new AdministratorAccountView(LogInUser);
                //administratorAccount.Show();
                HotelView view = new HotelView(LogInUser);
                view.Show();
                Close();
                return;
            }
            if(failureNumber == 3)
            {
                Close();
            }
        }

    }
}
