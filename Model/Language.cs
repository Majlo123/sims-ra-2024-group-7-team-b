﻿using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Model
{
    public class Language : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Language()
        {

        }

        public Language(string name)
        {
            Name = name;
        }

        public string[] ToCSV()
        {
            string[] values = { Id.ToString(), Name };
            return values;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = Convert.ToString(values[1]);

        }
    }
}
