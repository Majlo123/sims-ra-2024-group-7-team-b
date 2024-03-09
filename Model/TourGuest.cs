﻿using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Model
{
    public class TourGuest : ISerializable
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int TourReservationId { get; set; }
        public int CheckPointId { get; set; }
        public TourGuest() 
        {
        
        }

        public TourGuest(string fullName, int age, int tourReservationId, int checkPointId)
        {
            FullName = fullName;
            Age = age;  
            TourReservationId = tourReservationId;
            CheckPointId = checkPointId;
        }

        public string[] ToCSV()
        {
            string[] values = { Id.ToString(), FullName, Age.ToString(), TourReservationId.ToString(), CheckPointId.ToString() };
            return values;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            FullName = Convert.ToString(values[1]);
            Age = Convert.ToInt32(values[2]);
            TourReservationId= Convert.ToInt32(values[3]);
            CheckPointId= Convert.ToInt32(values[4]);
        }
    }
}
