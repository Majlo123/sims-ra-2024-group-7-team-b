using BookingApp.DTO;
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

namespace BookingApp.View.Guest
{
    /// <summary>
    /// Interaction logic for AccommodationDetailsView.xaml
    /// </summary>
    public partial class AccommodationDetailsView : Window
    {
        AccommodationDTO accommodation {  get; set; }
        public User Guest { get; set; }
        public AccommodationDetailsView(AccommodationDTO selected, User user)
        {
            InitializeComponent();
            DataContext = this;
            accommodation = selected;
            Guest = user;
            Initialize();
        }

        public void Initialize()
        {
            
            NameLabel.Content = accommodation.Name;
            LocationLabel.Content = accommodation.MergedLocation;
            TypeLabel.Content = accommodation.Type.ToString();
            MaxGuestsLabel.Content = accommodation.MaxGuests.ToString();
            MinReservationLabel.Content = accommodation.MinReservationDays.ToString();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ReserveAccommodationView reserveView = new ReserveAccommodationView(accommodation, Guest);
            reserveView.Owner=this;
            reserveView.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            reserveView.ShowDialog();
        }
    }
}
