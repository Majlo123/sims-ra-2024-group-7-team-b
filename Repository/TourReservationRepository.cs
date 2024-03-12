using BookingApp.Model;
using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repository
{
        public class TourReservationRepository
    {
        private const string FilePath = "../../../Resources/Data/tour-reservation.csv";

        private readonly Serializer<TourReservation> _serializer;

        private List<TourReservation> _tourReservations;

        public TourReservationRepository()
        {
            _serializer = new Serializer<TourReservation>();
            _tourReservations = _serializer.FromCSV(FilePath);
        }

        public List<TourReservation> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public TourReservation Save(TourReservation tourReservation)
        {
            tourReservation.Id = NextId();
            _tourReservations = _serializer.FromCSV(FilePath);
            _tourReservations.Add(tourReservation);
            _serializer.ToCSV(FilePath, _tourReservations);
            return tourReservation;
        }

        public int NextId()
        {
            _tourReservations = _serializer.FromCSV(FilePath);
            if (_tourReservations.Count < 1)
            {
                return 1;
            }
            return _tourReservations.Max(c => c.Id) + 1;
        }

        public void Delete(TourReservation tourReservation)
        {
            _tourReservations = _serializer.FromCSV(FilePath);
            TourReservation founded = _tourReservations.Find(c => c.Id == tourReservation.Id);
            if (founded != null)
            {
                _tourReservations.Remove(founded);
            }
            _serializer.ToCSV(FilePath, _tourReservations);
        }
    }
}
