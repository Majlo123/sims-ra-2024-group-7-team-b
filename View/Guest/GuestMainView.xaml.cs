using BookingApp.DTO;
using BookingApp.Model;
using BookingApp.Repository;
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

        public ObservableCollection<LocationDTO> locations { get; set; }
        public LocationDTO selectedLocation { get; set; }
        private LocationRepository locationRepository { get; set; }

        private AccommodationRepository accommodationRepository { get; set; }
        public User Guest { get; set; }
        public GuestMainView(User user)
        {
            InitializeComponent();
            DataContext = this;
            accommodations = new ObservableCollection<AccommodationDTO>();
            locations = new ObservableCollection<LocationDTO>();
            locationRepository = new LocationRepository();
            accommodationRepository = new AccommodationRepository();
            Guest = user;
            InitializeLocation();
            Update();
        }

        
        public void InitializeLocation()
        {
            Location empty = new Location(-1, "", "");
            locations.Clear();
            locations.Add(new LocationDTO(empty));
            foreach (Location location in locationRepository.GetAll())
            {
                locations.Add(new LocationDTO(location));
            }
            LocationComboBox.SelectedIndex = 0;
            selectedLocation = new LocationDTO(empty);
           
        }
        public void Update()
        {
            accommodations.Clear();
            foreach(Accommodation accommodation in accommodationRepository.GetAll())
            {
                
                accommodation.Location = locationRepository.Get(accommodation.Location.Id);
                
                accommodations.Add(new AccommodationDTO(accommodation));
            }
            
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchAccommodationParams searchParams = new SearchAccommodationParams();
            accommodations.Clear();
            foreach(Accommodation accommodation in GetSuitableAccommodations(searchParams)) 
            {
                accommodation.Location = locationRepository.Get(accommodation.Location.Id);
                accommodations.Add(new AccommodationDTO(accommodation));
            }
            
        }
        private SearchAccommodationParams GetSearchAccommodationParams()
        {
            int maxGuests;
            if (int.TryParse(MaxGuestsTextBox.Text, out maxGuests) == false)
            {
                maxGuests = -1;
            }
            int lenghtOfStay;
            if (int.TryParse(LenghtOfStayTextBox.Text, out lenghtOfStay) == false)
            {
                lenghtOfStay = -1;
            }
            return new SearchAccommodationParams(NameTextBox.Text, GetSuitableTypes(), selectedLocation.Id, maxGuests, lenghtOfStay);
        }

        private List<Accommodation> GetSuitableAccommodations(SearchAccommodationParams searchParams)
        {
            List<Accommodation> suitableAccommodations = new List<Accommodation>();
            foreach (Accommodation accommodation in accommodationRepository.GetAll())
            {
                if(IsAccommodationSuitable(accommodation, searchParams))
                {
                    suitableAccommodations.Add(accommodation);
                }
            }
            return suitableAccommodations;
        }

        private bool IsAccommodationSuitable(Accommodation accommodation, SearchAccommodationParams searchParams)
        {
            if (!IsTypeSuitable(accommodation, searchParams.Types) ||
                !IsNameSuitable(accommodation, searchParams.Name) ||
                !IsLocationSuitable(accommodation, searchParams.LocationId) ||
                !IsMaxGuestsSuitable(accommodation, searchParams.MaxGuests) ||
                !IsLengthOfStaySuitable(accommodation, searchParams.StayLength))
            {
                return false;
            }

            return true;
        }

        private bool IsTypeSuitable(Accommodation accommodation, List<Model.Enumeration.AccommodationType> types)
        {
            return (types.Count == 0 || types.Contains(accommodation.Type));
        }

        private bool IsNameSuitable(Accommodation accommodation, string name)
        {
            return (string.IsNullOrEmpty(name) || accommodation.Name.ToLower().Contains(name.ToLower()));
        }

        private bool IsLocationSuitable(Accommodation accommodation, int locationId)
        {
            return (locationId == -1 || locationId == accommodation.Location.Id);
        }

        private bool IsMaxGuestsSuitable(Accommodation accommodation, int maxGuests)
        {
            return (maxGuests == -1 || maxGuests <= accommodation.MaxGuests);
        }

        private bool IsLengthOfStaySuitable(Accommodation accommodation, int lengthOfStay)
        {
            return (lengthOfStay == -1 || lengthOfStay >= accommodation.MinReservationDays);
        }


        private List<Model.Enumeration.AccommodationType> GetSuitableTypes()
        {
            List<Model.Enumeration.AccommodationType> types = new List<Enumeration.AccommodationType>();
            if (ApartmentCheckBox.IsChecked == true)
            {
                types.Add(Enumeration.AccommodationType.Apartment);
            }
            if(HouseCheckBox.IsChecked == true)
            {
                types.Add(Enumeration.AccommodationType.House);
            }
            if(CottageCheckBox.IsChecked==true)
            {
                types.Add(Enumeration.AccommodationType.Cottage);
            }

            return types;
         }

        private void ReserveButton_Click(object sender, RoutedEventArgs e)
        {
            AccommodationDetailsView detail = new AccommodationDetailsView(selectedAccommodation, Guest);
            detail.Owner = this;
            detail.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            detail.Show();
        }
    }
}
