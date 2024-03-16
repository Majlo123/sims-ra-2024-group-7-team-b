using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.DTO
{
    public class AccommodationReservationDTO:INotifyPropertyChanged
    {
        public int Id {  get; set; }
        private string startDate;
        public string StartDate
        {
            get { return startDate; } 
            set {
                if(startDate != value)
                {
                    startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        private string endDate;
        public string EndDate
        {
            get { return endDate; }
            set
            {
                if(endDate != value)
                {
                    endDate = value; 
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }
        public int UserId {  get; set; }
        public int AccommodationId { get; set; }

        public AccommodationReservationDTO(int id, DateOnly start, DateOnly end, int userId, int accommodationId)
        {
            Id = id;
            StartDate = start.ToString();
            EndDate = end.ToString();
            UserId = userId;
            AccommodationId = accommodationId;
        }

        public AccommodationReservation ToAccommodationReservation(AccommodationReservationDTO accommodationReservation)
        {

            return new AccommodationReservation(Id, new Accommodation() { Id = AccommodationId}, new User() { Id = UserId }, DateOnly.Parse(StartDate), DateOnly.Parse(EndDate));
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
    }
}
