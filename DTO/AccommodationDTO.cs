using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.DTO
{
    public class AccommodationDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        private Location location;
        public Location Location
        {
            get { return location; }
            set
            {
                if (value != location)
                {
                    location = value;
                    OnPropertyChanged(nameof(Location));
                }
            }
        }
        private Model.Enumeration.AccommodationType type;
        public  Model.Enumeration.AccommodationType Type
        {
            get { return type; }
            set
            {
                if(value != type)
                {
                    type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }
        private int maxGuests;
        public int MaxGuests
        {
            get { return maxGuests; }
            set
            {
                if(value != maxGuests)
                {
                    maxGuests = value;
                    OnPropertyChanged(nameof(MaxGuests));
                }
            }
        }
        private int minReservationDays;
        public int MinReservationDays
        {
            get { return minReservationDays; }
            set
            {
                if(value!= minReservationDays)
                {
                    minReservationDays = value;
                    OnPropertyChanged(nameof(MinReservationDays));
                }
            }
        }
        private int uncancellablePeriod;
        public int UncancellablePeriod
        {
            get { return uncancellablePeriod; }
            set
            {
                if(value!=  uncancellablePeriod)
                {
                    uncancellablePeriod = value;
                    OnPropertyChanged(nameof(UncancellablePeriod));
                }
            }
        }
        private User owner;
        public User Owner 
        {
            get { return owner; }
            set 
            {
                if (value != owner)
                { 
                    owner = value;
                    OnPropertyChanged(nameof(Owner));
                }
            }
        }
        public AccommodationDTO() { }
        public AccommodationDTO(Accommodation accommodation)
        {
            Id = accommodation.Id;
            Name = accommodation.Name;
            Location = accommodation.Location;
            MaxGuests = accommodation.MaxGuests;
            MinReservationDays = accommodation.MinReservationDays;
            UncancellablePeriod = accommodation.UncancellablePeriod;
            Owner = accommodation.Owner;
        }
        public Accommodation ToAccommodation()
        {
            return new Accommodation(Id, name, location, type,  maxGuests, minReservationDays, uncancellablePeriod,owner);
        }

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
    }
}
