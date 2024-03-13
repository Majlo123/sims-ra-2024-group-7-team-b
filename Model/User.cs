using BookingApp.Serializer;
using System;

namespace BookingApp.Model
{
    public class User : ISerializable
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Enumeration.UserType Type { get; set; }
        public User() { }

        public User(string username, string password, Enumeration.UserType type)
        {
            Username = username;
            Password = password;
            Type = type;
        }

        public string[] ToCSV()
        {
            string[] csvValues = { Id.ToString(), Username, Password,((int)Type).ToString()};
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Username = values[1];
            Password = values[2];
            Type = (Enumeration.UserType)(Convert.ToInt32(values[3]));
        }
    }
}
