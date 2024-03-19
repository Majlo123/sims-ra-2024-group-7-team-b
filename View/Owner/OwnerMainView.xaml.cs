using BookingApp.DTO;
using BookingApp.Model;
using BookingApp.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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
        public ObservableCollection<AccommodationReservationDTO> accommodationReservationDTOsToGrade { get; set; }
        public ObservableCollection<AccommodationReservation> accommodationReservationsToGrade { get; set; }

        public AccommodationReservationDTO selectedReservation { get; set; }
        public List<AccommodationReservation> reservations { get; set; }
        private AccommodationRepository accommodationRepository { get; set; }
        private AccommodationReservationRepository accommodationReservationRepository { get; set; }



        public OwnerMainView(User user)
        {
            InitializeComponent();
            DataContext = this;
            User = user;
            accommodationReservationDTOsToGrade = new ObservableCollection<AccommodationReservationDTO>();
            accommodationRepository = new AccommodationRepository();
            accommodationReservationRepository = new AccommodationReservationRepository();
            reservations = new List<AccommodationReservation>();
            accommodationReservationsToGrade = new ObservableCollection<AccommodationReservation>();
            selectedReservation = new AccommodationReservationDTO();
            Update();
            if (accommodationReservationDTOsToGrade.Count != 0) 
            {
                MessageBox.Show("You have reservations to grade", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddAccommodationView addAccommodationView = new AddAccommodationView(User);
            addAccommodationView.ShowDialog();
        }
        private void Update()
        {
            accommodationReservationsToGrade.Clear();
            reservations.Clear();
            accommodationReservationDTOsToGrade.Clear();
            foreach (Accommodation accommodation in accommodationRepository.GetAccommodationsByOwnerId(User.Id)) 
            {
                putReservations(accommodationReservationRepository.GetByAccommodation(accommodation));
            }
            accommodationReservationsToGrade = new ObservableCollection<AccommodationReservation>(accommodationReservationRepository.GetReservationsWithinNDays(5, reservations));
            convertToDTOs(accommodationReservationsToGrade);
        }
        
        private void putReservations(List<AccommodationReservation> reservations)
        {

            foreach (AccommodationReservation accommodationReservation in reservations)
            {
                this.reservations.Add(accommodationReservation);
            }
        }
        private void convertToDTOs(ObservableCollection<AccommodationReservation> accommodationReservations)
        {
            foreach (AccommodationReservation accommodationReservation in accommodationReservations)
            {
                accommodationReservationDTOsToGrade.Add(new AccommodationReservationDTO(accommodationReservation));
            }
        }

        private void Grade_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
