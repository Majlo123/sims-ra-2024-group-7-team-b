using BookingApp.DTO;
using BookingApp.Model;
using BookingApp.Repository;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace BookingApp.View.Tourist
{
    public partial class TouristMainView : Window
    {

        public TourDTO SelectedTour {  get; set; }
        public ObservableCollection<TourDTO> Tours { get; set; }
        public ObservableCollection<TourDTO> FilteredTours { get; set; }
        public ObservableCollection<LocationDTO> Locations { get; set; }

        public ObservableCollection<LanguageDTO> Languages { get; set; }

        public TourRepository TourRepository;
        private LocationRepository LocationRepository { get; set; }

        private LanguageRepository LanguageRepository { get; set; }
        

       
        public TouristMainView()
        {
            InitializeComponent();
            DataContext = this;
            TourRepository = new TourRepository();
            Tours = new ObservableCollection<TourDTO>();
            Locations = new ObservableCollection<LocationDTO>();
            Languages = new ObservableCollection<LanguageDTO>();
            LocationRepository = new LocationRepository();
            LanguageRepository = new LanguageRepository();
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
        public void InitializeLanguage()
        {
            foreach(Language language in LanguageRepository.GetAll())
            {
                Languages.Add(new LanguageDTO(language));
            }
        }
        public void UpdateTours()
        {
            Tours.Clear();
            foreach (Tour tour in TourRepository.GetAll())
            {
                InitializeLocation();
                tour.Location = LocationRepository.Get(tour.Location.Id);
                InitializeLanguage();
                tour.Language = LanguageRepository.Get(tour.Language.Id);
                Tours.Add(new TourDTO(tour));
            }

        }

        private ObservableCollection<TourDTO> FilterByLocation(ObservableCollection<TourDTO> tours, string locationInput)
        {

            if (string.IsNullOrEmpty(locationInput))
            return tours;

            return new ObservableCollection<TourDTO>(tours.Where(tour => MatchesLocation(tour, locationInput)));
        
        }

        private ObservableCollection<TourDTO> FilterByDuration(ObservableCollection<TourDTO> tours, string durationInput)
        {
            if (string.IsNullOrEmpty(durationInput))
                return tours;

            return new ObservableCollection<TourDTO>(tours.Where(tour => tour.Duration.ToString() == durationInput));
        }

        private ObservableCollection<TourDTO> FilterByLanguage(ObservableCollection<TourDTO> tours, string languageInput)
        {
            if (string.IsNullOrEmpty(languageInput))
                return tours;

            return new ObservableCollection<TourDTO>(tours.Where(tour => tour.Language.Name.ToLower().Contains(languageInput)));
        }

        private ObservableCollection<TourDTO> FilterByGuests(ObservableCollection<TourDTO> tours, int numGuestsInput)
        {
            if (numGuestsInput <= 0)
                return tours;

            return new ObservableCollection<TourDTO>(tours.Where(tour => numGuestsInput <= tour.MaxGuests));
        }

        private ObservableCollection<TourDTO> ApplyFilters(ObservableCollection<TourDTO> tours, string locationInput, string durationInput, string languageInput, int numGuestsInput)
        {
            ObservableCollection<TourDTO> filteredTours = tours;

            filteredTours = FilterByLocation(filteredTours, locationInput);
            filteredTours = FilterByDuration(filteredTours, durationInput);
            filteredTours = FilterByLanguage(filteredTours, languageInput);
            filteredTours = FilterByGuests(filteredTours, numGuestsInput);

            return filteredTours;
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            UpdateTours();
            string locationInput = TextBoxLocation.Text.Trim().ToLower();
            string durationInput = TextBoxDuration.Text.Trim();
            string languageInput = TextBoxLanguage.Text.Trim().ToLower();
            int numGuestsInput = int.TryParse(TextBoxNumGuest.Text.Trim(), out numGuestsInput) ? numGuestsInput : 0;

            FilteredTours = ApplyFilters(Tours, locationInput, durationInput, languageInput, numGuestsInput);
            Table.ItemsSource = FilteredTours;
        }

        
        void ResetLocation() {
            FilteredTours.Clear();
            foreach (var tour in Tours)
            {
                
                if (SelectedTour==null||tour.Location.City != SelectedTour.Location.City || tour.MaxGuests==0)
                    continue;
                
                FilteredTours.Add(tour);

            }
            
            
        }
        void ClearEmptyTourSelection()
        {
            
            
            FilteredTours.Clear();
            
            foreach (var tour in Tours)
            {
                if(tour.Location.City != SelectedTour.Location.City && tour.MaxGuests != 0)
                    FilteredTours.Add(tour);
                else
                    continue;

               

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
                MessageBox.Show("Please select a tour.");
                return;
            }

            if (SelectedTour.MaxGuests == 0)
            {
                ResetLocation();
                if (FilteredTours.Count() != 0)
                {
                    MessageBox.Show("The tour is full. Showing available tours in the same location.");
                    Table.ItemsSource = FilteredTours;
                    return;
                }
                else
                {
                    MessageBox.Show("The tour is full. There are no available tours in the same location.");
                    ClearEmptyTourSelection();
                    return;
                }
            }

            TourReservationView tourReservationView = new TourReservationView(SelectedTour);
            tourReservationView.ShowDialog();
        }



    }
}
