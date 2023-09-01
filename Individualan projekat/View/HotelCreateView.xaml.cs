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
                    OnPropertyChanged("Code");
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
                    OnPropertyChanged("NameA");
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
                    OnPropertyChanged("ConstructionYear");
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
                    OnPropertyChanged("StarsNumber");
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
                    OnPropertyChanged("OwnerJmbg");

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

                if (columnName == "Code")
                {
                    if (columnName == "Code")
                    {
                        if (string.IsNullOrEmpty(Code))
                        {
                            return "Field is empty";
                        }

                        if (!Regex.IsMatch(Code, @"^[a-zA-Z]{1,3}$"))
                        {
                            return "Field has to have max 3 letters";
                        }
                    }
                }
                if (columnName == "NameA")
                {
                    if (columnName == "NameA")
                    {
                        if (string.IsNullOrEmpty(Code))
                        {
                            return "Field is empty";
                        }

                        if (!Regex.IsMatch(NameA, "^[a-zA-Z]+$"))
                        {
                            return "Field requires only letters";
                        }
                    }
                }
                if(columnName == "ConstructionYear")
                {
                    if (ConstructionYear == 0)
                    {
                        return "Field is empty";
                    }

                    if (ConstructionYear < 1000 || ConstructionYear > 9999)
                    {
                        return "Construction year must be a four-digit number.";
                    }
                }
                if (columnName == "StarsNumber")
                {
                    if (StarsNumber == 0)
                    {
                        return "Field is empty";
                    }

                    if (StarsNumber < 1 || StarsNumber > 5)
                    {
                        return "Stars number must be between 1 and 5";
                    }
                }
                if (columnName == "OwnerJmbg")
                {
                    if (columnName == "OwnerJmbg")
                    {
                        if (string.IsNullOrEmpty(OwnerJmbg))
                        {
                            return "Field is empty";
                        }
                        if (OwnerJmbg.Length != 13)
                        {
                            return "JMBG must be exactly 13 digits long.";
                        }

                        if (!OwnerJmbg.All(char.IsDigit))
                        {
                            return "JMBG can only contain digits.";
                        }
                    }
                }
                return null;
            }

        }
        private readonly string[] _validatedProperties = { "Code", "NameA", "ConstructionYear", "StarsNumber", "OwnerJmbg" };

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

        private void CreateHotel(object sender, RoutedEventArgs e)
        {
            if(IsValid)
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
}
