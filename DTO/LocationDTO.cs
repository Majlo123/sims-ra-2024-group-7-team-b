using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.DTO
{
    public class LocationDTO:INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string fullLocation;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string FullLocation
        {
            get { return fullLocation; }
            set
            {
                if(fullLocation != value)
                {
                    fullLocation = value;
                    OnPropertyChanged(nameof(FullLocation));
                }
            }
        }
        public LocationDTO()
        {
            
        }
        public LocationDTO(Location location)
        {
            Id = location.Id;
            FullLocation = location.City + ", " + location.Country;
        }
        public Location ToLocation()
        {
            string[] splits = FullLocation.Split(',');
            return new Location(splits[1], splits[0]);
        }
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
    }
}
