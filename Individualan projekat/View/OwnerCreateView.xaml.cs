using Individualan_projekat.Model;
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
using Individualan_projekat.ServiceInterfaces;
using Individualan_projekat.Util;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Individualan_projekat.View
{
    /// <summary>
    /// Interaction logic for OwnerCreateView.xaml
    /// </summary>
    public partial class OwnerCreateView : Window
    {
        private IOwnerService _ownerService;

        private readonly IAdministratorService _adminstratorService;
        private readonly IGuestService _guestService;
        public OwnerCreateView()
        {
            InitializeComponent();
            this.DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            _ownerService = InjectorService.CreateInstance<IOwnerService>();
            _adminstratorService = InjectorService.CreateInstance<IAdministratorService>();
            _guestService = InjectorService.CreateInstance<IGuestService>();

        }
        public string JMBG { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NameA { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        

        private void CreateOwner(object sender, RoutedEventArgs e)
        {
            var tmp = _ownerService.GetAll().Find(o => o.Email == Email || o.Jmbg == JMBG);
            if(tmp != null)
            {
                MessageBox.Show("Try again. Email or JMBG already exists", "Alert");
                return;
            }
            Owner o = new Owner();
            o.Jmbg = JMBG;
            o.Email = Email;
            o.Password = Password;
            o.Name = NameA;
            o.Surname = Surname;
            o.PhoneNumber = PhoneNumber;
            _ownerService.Create(o);
            AllUsersView.Users.Add(o);
            this.Close();
        }

    }
}
