using BookingApp.Model;
using BookingApp.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Image = BookingApp.Model.Image;

namespace BookingApp.View.Guide
{
    /// <summary>
    /// Interaction logic for CreateTour.xaml
    /// </summary>
    public partial class CreateTour : Window
    {
        private readonly TourRepository _tourRepository;
        private readonly CheckPointRepository _checkPointRepository;
        private readonly TourTimeRepository _tourTimeRepository;
        private readonly LocationRepository _locationRepository;

        public User LoggedInUser { get; set; }
        public ObservableCollection<Image> Images { get; set; }
        private string _name;
        private Location _location;
        private string _description;
        private Language _language;
        private int _maxGuests;
        private CheckPoint _checkPoint;
        private TourTime _tourTime;
        private double _duration;

        public CreateTour()
        {
            InitializeComponent();
        }
        private void UploadURL(object sender, RoutedEventArgs e)
        {

        }

        private void CreateTour_Click(object sender, RoutedEventArgs e)
        {

        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Click_AddCheckPoint(object sender, RoutedEventArgs e)
        {

        }
        private void Click_AddTourDate(object sender, RoutedEventArgs e)
        {

        }


    }
}
