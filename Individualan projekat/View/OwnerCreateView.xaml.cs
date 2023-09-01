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
    public partial class OwnerCreateView : Window, INotifyPropertyChanged
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

        private string _jmbg;
        public string JMBG
        {
            get { return _jmbg; }
            set
            {
                if(_jmbg != value)
                {
                    value = _jmbg;
                    OnPropertyChanged("JMBG");
                }
            }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    value = _email;
                    OnPropertyChanged("Email");
                }
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    value = _password;
                    OnPropertyChanged("Password");
                }
            }
        }
        private string _name;
        public string NameA
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    value = _name;
                    OnPropertyChanged("NameA");
                }
            }
        }
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    value = _surname;
                    OnPropertyChanged("Surname");
                }
            }
        }
        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                {
                    value = _phoneNumber;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string this[string columnName]
        {
            get
            {

                if (columnName == "JMBG")
                {
                    if (columnName == "JMBG")
                    {
                        if (string.IsNullOrEmpty(JMBG))
                        {
                            return "Field is empty";
                        }
                        if (JMBG.Length != 13)
                        {
                            return "JMBG must be exactly 13 digits long.";
                        }

                        if (!JMBG.All(char.IsDigit))
                        {
                            return "JMBG can only contain digits.";
                        }
                    }
                }
                if (columnName == "Email")
                {
                    if (columnName == "Email")
                    {
                        if (string.IsNullOrEmpty(Email))
                        {
                            return "Field is empty";
                        }
                        if (!Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                        {
                            return "Invalid form";
                        }
                    }
                }
                if (columnName == "Password")
                {
                    if (columnName == "Password")
                    {
                        if (string.IsNullOrEmpty(Password))
                        {
                            return "Field is empty";
                        }
                        if (!Regex.IsMatch(Password, @"^[a-zA-Z]{1,3}$"))
                        {
                            return "Invalid form";
                        }
                    }
                }

                if (columnName == "NameA")
                {
                    if (columnName == "NameA")
                    {
                        if (string.IsNullOrEmpty(NameA))
                        {
                            return "Field is empty";
                        }
                        if (!Regex.IsMatch(NameA, "^[a-zA-Z]+$"))
                        {
                            return "Only letters";
                        }
                    }
                }
                if (columnName == "Surname")
                {
                    if (columnName == "Surname")
                    {
                        if (string.IsNullOrEmpty(Surname))
                        {
                            return "Field is empty";
                        }
                        if (!Regex.IsMatch(Surname, "^[a-zA-Z]+$"))
                        {
                            return "Only letters";
                        }
                    }
                }
                if (columnName == "PhoneNumber")
                {
                    if (columnName == "PhoneNumber")
                    {
                        if (string.IsNullOrEmpty(PhoneNumber))
                        {
                            return "Field is empty";
                        }
                        if (!int.TryParse(PhoneNumber, out int phoneNumberValue))
                        {
                            return "Invalid input";
                        }

                        if (phoneNumberValue != 10)
                        {
                            return "Invalid input";
                        }
                    }
                }
                return null;
            }

        }
        private readonly string[] _validatedProperties = { "JMBG", "Email", "Password", "NameA", "Surname", "PhoneNumber" };

        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (this[property] != null)
                        return false;
                }

                return true;
            }
        }

        private void CreateOwner(object sender, RoutedEventArgs e)
        {
            if(IsValid)
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
}
