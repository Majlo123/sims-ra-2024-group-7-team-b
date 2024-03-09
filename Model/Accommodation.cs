using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xaml.Schema;

namespace BookingApp.Model
{
    public class Accommodation : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Location Location { get; set; }
        //public AccommodationType Type { get; set; }
        
        public int MaxGuests { get; set; }
        public int MinReservationDays { get; set; }

        public int UncancellablePeriod { get; set; }//Number of days before reservation where you can't cancel
        //public List<Image>? Images { get; set; }

        public Accommodation()
        {
            
        }

        public Accommodation(string name, Location location, int maxGuests, int minReservation)
        {
            this.Name = name;
            this.Location = location;
            this.MaxGuests = maxGuests;
            this.MinReservationDays = minReservation;
            this.UncancellablePeriod = 1;
            //this.Images = new List<Image>();
        }
        public Accommodation(string name,Location location,  int maxGuests, int minReservation, int uncancellablePreriod)
        {
            this.Name = name;
            this.MaxGuests = maxGuests;
            this.MinReservationDays = minReservation;
            this.UncancellablePeriod = uncancellablePreriod;
            //this.Images = new List<Image>();
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = values[1];
            Location = new Location() { Id = Convert.ToInt32(values[2]) };
            MaxGuests = Convert.ToInt32(values[3]);
            MinReservationDays = Convert.ToInt32(values[4]);
            UncancellablePeriod = Convert.ToInt32(values[6]);
            
        }

        public string[] ToCSV()
        {
            string[] values = {Id.ToString(), Name.ToString(), Location.Id.ToString(), MaxGuests.ToString(), MinReservationDays.ToString(), UncancellablePeriod.ToString()};
            return values;
        }
    }
}
