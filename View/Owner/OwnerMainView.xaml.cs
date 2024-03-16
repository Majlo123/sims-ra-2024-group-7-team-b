using BookingApp.Model;
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

namespace BookingApp.View.Owner
{
    /// <summary>
    /// Interaction logic for OwnerMainView.xaml
    /// </summary>
    public partial class OwnerMainView : Window
    {
        public User User { get; set; }
        public OwnerMainView(User user)
        {
            this.User = user;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddAccommodationView addAccommodationView = new AddAccommodationView(User);
            addAccommodationView.ShowDialog();
        }
    }
}
