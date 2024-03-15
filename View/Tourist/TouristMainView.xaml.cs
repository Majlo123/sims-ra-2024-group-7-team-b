using BookingApp.DTO;
using BookingApp.Model;
using BookingApp.Repository;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace BookingApp.View.Tourist
{
    public partial class TouristMainView : Window
    {
        public TourDTO SelectedTour { get; set; }
        public ObservableCollection<TourDTO> Tours { get; set; }
        public ObservableCollection<TourDTO> FilteredTours { get; set; }
        public ObservableCollection<LocationDTO> Locations { get; set; }
        public TourRepository TourRepository;
        private LocationRepository LocationRepository { get; set; }

        public TouristMainView()
        {
            InitializeComponent();
            DataContext = this;
            TourRepository = new TourRepository();
            Tours = new ObservableCollection<TourDTO>();
            Locations = new ObservableCollection<LocationDTO>();
            LocationRepository = new LocationRepository();
            FilteredTours = new ObservableCollection<TourDTO>();
            UpdateTours();
        }

        public void InitializeLocation()
        {

            foreach (Location location in LocationRepository.GetAll())
            {
                Locations.Add(new LocationDTO(location));
            }


        }
        public void UpdateTours()
        {
            Tours.Clear();
            foreach (Tour tour in TourRepository.GetAll())
            {
                InitializeLocation();
                tour.Location = LocationRepository.Get(tour.Location.Id);

                Tours.Add(new TourDTO(tour));
            }

        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            string locationInput = TextBoxLocation.Text.Trim().ToLower();
            string durationInput = TextBoxDuration.Text.Trim();
            string languageInput = TextBoxLanguage.Text.Trim().ToLower();
            int numGuestsInput = int.TryParse(TextBoxNumGuest.Text.Trim(), out numGuestsInput) ? numGuestsInput : 0;

            FilteredTours.Clear();
            foreach (var tour in Tours)
            {
                if (!MatchesLocation(tour, locationInput))
                    continue;

                if (!string.IsNullOrEmpty(durationInput) && tour.Duration.ToString() != durationInput)
                    continue;

                if (!string.IsNullOrEmpty(languageInput) && !tour.Language.Name.ToLower().Contains(languageInput))
                    continue;

                if (numGuestsInput > 0 && numGuestsInput > tour.MaxGuests)
                    continue;

                FilteredTours.Add(tour);
            }

            Table.ItemsSource = FilteredTours;
        }

        private bool MatchesLocation(TourDTO tour, string locationInput)
        {
            if (string.IsNullOrEmpty(locationInput))
                return true;

            string[] locationParts = locationInput.Split(',');
            if (locationParts.Length != 2)
                return false;

            string city = locationParts[0].Trim().ToLower();
            string country = locationParts[1].Trim().ToLower();

            if (tour.Location == null)
                return false;

            string tourCity = tour.Location.City.Trim().ToLower();
            string tourCountry = tour.Location.Country.Trim().ToLower();

            return tourCity == city && tourCountry == country;
        }

        private void ReserveClick(object sender, RoutedEventArgs e)
        {
            if (SelectedTour == null)
            {
                MessageBox.Show("Please select a tour before making a reservation.");
                return;
            }

            // Implement reservation logic here
        }
    }
}
