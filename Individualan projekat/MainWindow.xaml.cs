using Individualan_projekat.Model;
using Individualan_projekat.Repository;
using Individualan_projekat.ServiceInterfaces;
using Individualan_projekat.Util;
using Individualan_projekat.View;
using System;
using System.Collections.Generic;
using System.Linq;
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
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

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
        bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }
        private bool ValidatePassword(string password)
        {
            return password.Length >= 3;
        }
        private void LogIn(object sender, RoutedEventArgs e)
        {
            Email = emailBox.Text;
            Password = passwordBox.Password;

            bool isEmailValid = ValidateEmail(Email);
            bool isPasswordValid = ValidatePassword(Password);

            if (!isEmailValid)
            {
                emailErrorText.Text = "Invalid email format";
                emailErrorText.Visibility = Visibility.Visible;
                failureNumber++;
                if (failureNumber >= 3)
                {
                    Close();
                }
            }
            else
            {
                emailErrorText.Visibility = Visibility.Collapsed;
            }

            if (!isPasswordValid)
            {
                passwordErrorText.Text = "Invalid password";
                passwordErrorText.Visibility = Visibility.Visible;
                failureNumber++;
                if (failureNumber >= 3)
                {
                    Close();
                }
            }
            else
            {
                passwordErrorText.Visibility = Visibility.Collapsed;
            }

            if (isEmailValid && isPasswordValid)
            {
                LogInUser = _ownerService.GetByEmailAndPassword(Email, Password);
                if (LogInUser != null)
                {
                    HotelView view = new HotelView(LogInUser);
                    view.Show();
                    Close();
                    return;
                }

                LogInUser = _guestService.GetByEmailAndPassword(Email, Password);
                if (LogInUser != null)
                {
                    HotelView view = new HotelView(LogInUser);
                    view.Show();
                    Close();
                    return;
                }

                LogInUser = _administratorService.GetByEmailAndPassword(Email, Password);
                if (LogInUser != null)
                {
                    HotelView view = new HotelView(LogInUser);
                    view.Show();
                    Close();
                    return;
                }

            }

        }
       
    }
}
