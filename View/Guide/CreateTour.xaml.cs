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

namespace BookingApp.View.Guide
{
    /// <summary>
    /// Interaction logic for CreateTour.xaml
    /// </summary>
    public partial class CreateTour : Window
    {
        private readonly TourRepository _tourRepository;
        //private readonly CheckPoint
        private readonly TourTimeRepository _tourTimeRepository;
        private readonly LocationRepository _locationRepository;

        public ObservableCollection<Image> Images { get; set; }
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
