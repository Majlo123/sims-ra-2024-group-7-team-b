using BookingApp.DTO;
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

namespace BookingApp.View.Guest
{
    /// <summary>
    /// Interaction logic for GuestMainView.xaml
    /// </summary>
    public partial class GuestMainView : Window
    {
        public ObservableCollection<AccommodationDTO> accommodations { get; set; }
        public AccommodationDTO selectedAccommodation { get; set; }
        public GuestMainView()
        {
            InitializeComponent();
        }
    }
}
