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
using Individualan_projekat.Model;
using Individualan_projekat.ServiceInterfaces;
using Individualan_projekat.Util;

namespace Individualan_projekat.View
{
    /// <summary>
    /// Interaction logic for AllUsersView.xaml
    /// </summary>
    public partial class AllUsersView : Window
    {
        public static ObservableCollection<User> Users { get; set; }

        private readonly IOwnerService _ownerService;
        private readonly IAdministratorService _adminstratorService;
        private readonly IGuestService _guestService;

        private string _selectedUser;
        public string SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
            }
        }

        public AllUsersView()
        {
            InitializeComponent();
            this.DataContext = this;

            _ownerService = InjectorService.CreateInstance<IOwnerService>();
            _adminstratorService = InjectorService.CreateInstance<IAdministratorService>(); 
            _guestService = InjectorService.CreateInstance<IGuestService>();    

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Init();
        }

        private void Init()
        {
            Users = new ObservableCollection<User>();
            foreach(var u in _ownerService.GetAll())
            {
                   Users.Add(u);
            }
            foreach(var u in _adminstratorService.GetAll())
            {
                Users.Add(u);
            }
            foreach(var u in _guestService.GetAll())
            {
                Users.Add(u);
            }
            UserType = new ObservableCollection<string>();
            UserType.Add("Guest");
            UserType.Add("Owner");
        }

        private void CreateOwnerClick(object sender, RoutedEventArgs e)
        {
            OwnerCreateView o = new OwnerCreateView();
            o.Show();
        }

        private void HotelsClick(object sender, RoutedEventArgs e)
        {
            HotelView h = new HotelView(MainWindow.LogInUser);
            h.Show();
            this.Close();
        }

        public ObservableCollection<string> UserType { get; set; }

        private void FilterClick(object sender, RoutedEventArgs e)
        {
            List<User> users = new List<User>();
            if(SelectedUser == "Owner")
            {
                Users.Clear();
                foreach (var u in _ownerService.GetAll())
                {
                    Users.Add(u);
                }
        
            }
            else if(SelectedUser == "Guest")
            {
                Users.Clear();
                foreach (var u in _guestService.GetAll())
                {
                    Users.Add(u);
                }
            }
        }


        private void ClearClick(object sender, RoutedEventArgs e)
        {
            Users.Clear();
            foreach (var u in _ownerService.GetAll())
            {
                Users.Add(u);
            }
            foreach (var u in _adminstratorService.GetAll())
            {
                Users.Add(u);
            }
            foreach (var u in _guestService.GetAll())
            {
                Users.Add(u);
            }
            myTextBox.Text = "";
        }

        private void SortByName(object sender, RoutedEventArgs e)
        {
            List<User> users = new List<User>();
            users.AddRange(_ownerService.GetAll());
            users.AddRange(_adminstratorService.GetAll());
            users.AddRange(_guestService.GetAll());
            
            Users.Clear();
            foreach(var u in users.OrderBy(u => u.Name).ToList())
            {
                Users.Add(u);
            }
        }

        private void SortBySurname(object sender, RoutedEventArgs e)
        {
            List<User> users = new List<User>();
            users.AddRange(_ownerService.GetAll());
            users.AddRange(_adminstratorService.GetAll());
            users.AddRange(_guestService.GetAll());

            Users.Clear();
            foreach(var u1 in users.OrderBy(u1 => u1.Surname).ToList())
            {
                Users.Add(u1);
            }

        }

        public User ChosenUser { get; set;  }

        private void Block(object sender, RoutedEventArgs e)
        {
            if(ChosenUser == null)
            {
                return;
            }
            ChosenUser.Blocked = true;
            if(ChosenUser is Guest)
            {
                _guestService.Update((Guest)ChosenUser);
            }
            else if(ChosenUser is Owner)
            {
                _ownerService.Update((Owner)ChosenUser);
            }
            else
            {
                _adminstratorService.Update((Administrator)ChosenUser);
            }
            ClearClick(sender, e);
        }

        private void Unblock(object sender, RoutedEventArgs e)
        {
            if (ChosenUser == null)
            {
                return;
            }
            ChosenUser.Blocked = false;
            if (ChosenUser is Guest)
            {
                _guestService.Update((Guest)ChosenUser);
            }
            else if (ChosenUser is Owner)
            {
                _ownerService.Update((Owner)ChosenUser);
            }
            else
            {
                _adminstratorService.Update((Administrator)ChosenUser);
            }
            ClearClick(sender, e);
        }

        private void SortByNameReversed(object sender, RoutedEventArgs e)
        {
            List<User> users = new List<User>();
            users.AddRange(_ownerService.GetAll());
            users.AddRange(_adminstratorService.GetAll());
            users.AddRange(_guestService.GetAll());

            Users.Clear();
            foreach (var uu in users.OrderByDescending(u => u.Name).ToList())
            {
                Users.Add(uu);
            }
        }

        private void SortBySurnameReversed(object sender, RoutedEventArgs e)
        {
            List<User> users = new List<User>();
            users.AddRange(_ownerService.GetAll());
            users.AddRange(_adminstratorService.GetAll());
            users.AddRange(_guestService.GetAll());

            Users.Clear();
            foreach (var u1 in users.OrderByDescending(u1 => u1.Surname).ToList())
            {
                Users.Add(u1);
            }
        }
    }
}
