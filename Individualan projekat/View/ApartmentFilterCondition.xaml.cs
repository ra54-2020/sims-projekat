using Individualan_projekat.Model;
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
    /// Interaction logic for ApartmentFilterCondition.xaml
    /// </summary>
    public partial class ApartmentFilterCondition : Window
    {
        public ObservableCollection<String> Apartments { get; set; }

        public ApartmentFilterCondition()
        {
            InitializeComponent();
            this.DataContext = this;

            Apartments = new ObservableCollection<String>();
            Apartments.Add("Room");
            Apartments.Add("People");
            Apartments.Add("Room and people");
        }
    }
}
