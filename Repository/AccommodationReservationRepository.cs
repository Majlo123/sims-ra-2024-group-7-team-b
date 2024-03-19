using BookingApp.DTO;
using BookingApp.Model;
using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repository
{
    public class AccommodationReservationRepository
    {
        private const string FilePath = "../../../Resources/Data/accommodation-reservations.csv";
        private readonly Serializer<AccommodationReservation> _serializer;

        private List<AccommodationReservation> _accommodationReservations;

        public AccommodationReservationRepository()
        {
            _serializer = new Serializer<AccommodationReservation>();
            _accommodationReservations = _serializer.FromCSV(FilePath);
        }
        public List<AccommodationReservation> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }
        public int NextId()
        {
            _accommodationReservations = _serializer.FromCSV(FilePath);
            if( _accommodationReservations.Count < 1)
            {
                return 1;
            }
            return _accommodationReservations.Max(x => x.Id) + 1;
        }
        public AccommodationReservation Save(AccommodationReservation accommodetionReservation)
        {
            accommodetionReservation.Id = NextId();
            _accommodationReservations = _serializer.FromCSV(FilePath);
            _accommodationReservations.Add(accommodetionReservation);
            _serializer.ToCSV(FilePath, _accommodationReservations);
            return accommodetionReservation;
        }
        public void Delete(AccommodationReservation accommodationReservation)
        {
            _accommodationReservations = _serializer.FromCSV(FilePath);
            AccommodationReservation founded = _accommodationReservations.Find(ar => ar.Id == accommodationReservation.Id);
            if( founded != null )
            {
                _accommodationReservations.Remove( founded );
            }
            _serializer.ToCSV(FilePath, _accommodationReservations);
        }
        public AccommodationReservation Update(AccommodationReservation accommodationReservation)
        {
            _accommodationReservations = _serializer.FromCSV(FilePath);
            AccommodationReservation current = _accommodationReservations.Find(ar => ar.Id == accommodationReservation.Id);
            int index = _accommodationReservations.IndexOf(current);
            _accommodationReservations[index] = accommodationReservation;
            _serializer.ToCSV(FilePath, _accommodationReservations);
            return accommodationReservation;
        }

        public List<AccommodationReservation> GetByAccommodation(Accommodation accommodation)
        {
            _accommodationReservations = _serializer.FromCSV(FilePath);
            return _accommodationReservations.FindAll(ar=>ar.Accommodation.Id == accommodation.Id);
        }

        public List<AccommodationReservation> GetByUser(User user)
        {
            _accommodationReservations = _serializer.FromCSV(FilePath);
            return _accommodationReservations.FindAll(ar => ar.User.Id == user.Id);
        }
        public List<AccommodationReservation> GetReservationsWithinNDays(int period,List<AccommodationReservation> accommodationReservations)
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Today);
            DateOnly nDaysAgo = currentDate.AddDays(-period);
            var reservationsWithinNDays = accommodationReservations.Where(r => r.EndDate > nDaysAgo && r.EndDate <= currentDate).ToList();
            return reservationsWithinNDays;
        }
    }
}
