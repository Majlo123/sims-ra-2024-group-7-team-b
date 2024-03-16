using BookingApp.Model;
using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repository
{
    public  class CheckPointRepository
    {
        private const string FilePath = "../../../Resources/Data/checkPoints.csv";

        private readonly Serializer<CheckPoint> _serializer;
        private List<CheckPoint> _checkPoints;

        public CheckPointRepository()
        {
            _serializer = new Serializer<CheckPoint>();
            _checkPoints = _serializer.FromCSV(FilePath);
        }
        public List<CheckPoint> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }
        public CheckPoint Get(int id)
        {
            List<CheckPoint> checkPoints = GetAll();
            return checkPoints.Find(l => l.Id == id);
        }

        public int NextId()
        {
            _checkPoints = GetAll();
            if (_checkPoints.Count < 1)
            {
                return 1;
            }
            return _checkPoints.Max(c => c.Id) + 1;
        }



    }
}
