using BookingApp.DTO;
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

namespace BookingApp.View.Guest
{
    /// <summary>
    /// Interaction logic for AvailableReservationDatesView.xaml
    /// </summary>
    public partial class AvailableReservationDatesView : Window
    {
        public ObservableCollection<AccommodationReservationDTO> choices {  get; set; }
        public List<DateOnly> StartDates { get; set; }
        public List<DateOnly> EndDates { get; set; }
        public int UserId { get; set; }
        public int AccommodationId { get; set; }
        public AccommodationReservationDTO SelectedDate { get; set; }

        public DateOnly ChosenStart;
        public DateOnly ChosenEnd;
        public bool isChosen;

        public AvailableReservationDatesView(string message, List<DateOnly> startDates, List<DateOnly> endDates, int userId, int accommodationId)
        {
            InitializeComponent();
            DataContext = this;
            StartDates = startDates; 
            EndDates = endDates;
            UserId = userId;
            AccommodationId = accommodationId;
            MessageLabel.Content = message;
            choices = new ObservableCollection<AccommodationReservationDTO>();
            Update();
        }
        private void Update()
        {
            choices.Clear();
            for(int i = 0; i < StartDates.Count; i++)
            {
                choices.Add(new AccommodationReservationDTO(-1, StartDates[i], EndDates[i], UserId, AccommodationId));
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            isChosen = false;
            Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedDate != null)
            {
                ChosenStart = DateOnly.Parse(SelectedDate.StartDate);
                ChosenEnd = DateOnly.Parse(SelectedDate.EndDate);
                isChosen = true;
                Close();
            }
            else
            {
                MessageBox.Show("You must select one date before you press confirm");
            }
            
        }
    }
}
