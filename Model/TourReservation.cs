using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace BookingApp.Model
{
    public class TourReservation: ISerializable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TourTimeId { get; set; }
        public TourReservation() 
        {
        
        }

        public TourReservation(int userId,int tourTimeId)
        {
            UserId = userId;
            TourTimeId = tourTimeId;
        }

        public string[] ToCSV()
        {
            string[] values = { Id.ToString(), UserId.ToString(), TourTimeId.ToString() };
            return values;
        }


        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            UserId= Convert.ToInt32(values[1]);
            TourTimeId= Convert.ToInt32(values[2]);

        }

    }
}
