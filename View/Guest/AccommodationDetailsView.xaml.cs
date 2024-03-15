using BookingApp.DTO;
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
        public AccommodationDetailsView(AccommodationDTO selected)
        {
            InitializeComponent();
            DataContext = this;
            accommodation = selected;
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
            ReserveAccommodationView reserve = new ReserveAccommodationView(accommodation);
            reserve.Owner=this;
            reserve.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            reserve.ShowDialog();
        }
    }
}
