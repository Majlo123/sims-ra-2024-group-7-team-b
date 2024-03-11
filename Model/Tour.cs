using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Model
{
    public class Tour: ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }
        public Language Language { get; set; }
        public int MaxGuests { get; set; }
        public CheckPoint CheckPoint { get; set; }
        public TourTime TourTime { get; set; }
        public double Duration { get; set; }

        //public List<Image>? Images { get; set; }

        public Tour() 
        {
        
        }

        public Tour(string name, Location location, string description, Language language, int maxGuests, CheckPoint checkPoint, TourTime tourTime, double duration)
        {
            Name = name;
            Location = location;
            Description = description;
            Language = language;
            MaxGuests = maxGuests;
            CheckPoint = checkPoint;
            TourTime = tourTime;
            Duration = duration;
        }
        

        public string[] ToCSV()
        {
            string[] values = { Id.ToString(), Name, Location.Id.ToString(), Description.ToString(), Language.Id.ToString(), 
                                MaxGuests.ToString(), CheckPoint.Id.ToString(), TourTime.Id.ToString(), Duration.ToString() };
            return values;
        }
        

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = Convert.ToString(values[1]);
            Location = new Location() { Id = Convert.ToInt32(values[2])};
            Description = Convert.ToString(values[3]);
            Language = new Language() { Id = Convert.ToInt32(values[4])};
            MaxGuests= Convert.ToInt32(values[5]);
            CheckPoint = new CheckPoint() {  Id = Convert.ToInt32(values[6])};
            TourTime=new TourTime() { Id = Convert.ToInt32(values[7])};
            Duration = Convert.ToDouble(values[8]);

        }
    }
}
