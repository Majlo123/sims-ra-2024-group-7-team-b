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
        public GuestMainView()
        {
            InitializeComponent();
            DataContext = this;
            accommodations = new ObservableCollection<AccommodationDTO>();
            locations = new ObservableCollection<LocationDTO>();
            locationRepository = new LocationRepository();
            accommodationRepository = new AccommodationRepository();
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
            
        }
        public void Update()
        {
            accommodations.Clear();
            foreach(Accommodation accommodation in accommodationRepository.GetAll())
            {
                accommodations.Add(new AccommodationDTO(accommodation));
            }
            
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            List<Model.Enumeration.AccommodationType> types = GetSuitableTypes();

            int locationId = selectedLocation.Id;
            int maxGuests;
            if(int.TryParse(MaxGuestsTextBox.Text, out maxGuests) == false)
            {
                maxGuests = -1;
            }
            int lenghtOfStay;
            if(int.TryParse(LenghtOfStayTextBox.Text, out lenghtOfStay) == false)
            {
                lenghtOfStay = -1;
            }
            foreach(Accommodation accommodation in GetSuitableAccommodations(name, types, locationId, maxGuests, lenghtOfStay)) 
            {
                accommodations.Add(new AccommodationDTO(accommodation));
            }
            
        }
        private List<Accommodation> GetSuitableAccommodations(string name, List<Model.Enumeration.AccommodationType> types, int locationId, int maxGuests, int lenghtOfStay)
        {
            List<Accommodation> suitableAccommodations = new List<Accommodation>();
            foreach (Accommodation accommodation in accommodationRepository.GetAll())
            {
                if(IsAccommodationSuitable(accommodation, name, types, locationId, maxGuests, lenghtOfStay))
                {
                    suitableAccommodations.Add(accommodation);
                }
                
            }

            return suitableAccommodations;
        }

        private bool IsAccommodationSuitable(Accommodation accommodation, string name, List<Model.Enumeration.AccommodationType> types, int locationId, int maxGuests, int lenghtOfStay)
        {
            if ((!types.Contains(accommodation.Type)) && types.Count != 0)
            { 
                return false;
            }
            if((!(accommodation.Name.ToLower().Contains(name.ToLower()))) && name != "")
            { 
                return false; 
            }
            if(locationId != -1  && locationId!= accommodation.Location.Id)
            {
                return false;
            }
            if(maxGuests != -1 && maxGuests <  accommodation.MaxGuests)
            { 
                return false;
            }
            if(lenghtOfStay != -1 && lenghtOfStay < accommodation.MinReservationDays)
            {
                return false;
            }

            return true;
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
    }
}
