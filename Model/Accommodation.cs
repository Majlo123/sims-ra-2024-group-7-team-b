using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookingApp.Model
{
    public class Accommodation : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int MaxGuests { get; set; }
        public int MinReservation { get; set; }

        
        public int UncancellablePeriod { get; set; }//Number of days before reservation where you can't cancel
        public List<string>? Images { get; set; }

        public Accommodation(string name, string city, string country, int maxGuests, int minReservation)
        { 
            this.Name = name;
            this.City = city;
            this.Country = country;
            this.MaxGuests = maxGuests;
            this.MinReservation = minReservation;
            this.UncancellablePeriod = 1;
            this.Images = new List<string>();
        }
        public Accommodation(string name, string city, string country, int maxGuests, int minReservation, int uncancellablePreriod)
        {
            this.Name = name;
            this.City = city;
            this.Country = country;
            this.MaxGuests = maxGuests;
            this.MinReservation = minReservation;
            this.UncancellablePeriod = uncancellablePreriod;
            this.Images = new List<string>();
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = values[1];
            City = values[2];
            Country = values[3];
            MaxGuests = Convert.ToInt32(values[4]);
            MinReservation = Convert.ToInt32(values[5]);
            UncancellablePeriod = Convert.ToInt32(values[6]);
            if (values.Length > 7)
            {
                if (values[7] == "")
                {
                    return;
                }

                string[] images = values[7].Split(',');
                if(Images != null)
                {
                    foreach (string image in images)
                    {
                        Images.Add(image);
                    }
                }
               
            }
        }

        public string[] ToCSV()
        {
            string[] values = {Id.ToString(), Name.ToString(), City.ToString(), Country, MaxGuests.ToString(), MinReservation.ToString(), UncancellablePeriod.ToString()};
            if (Images != null)
            {
                string images = String.Join(",", Images);
                values.Append(images);
            }
            return values;
        }
    }
}
