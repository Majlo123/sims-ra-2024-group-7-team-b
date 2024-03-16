using BookingApp.DTO;
using BookingApp.Model;
using BookingApp.Repository;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ReserveAccommodationView.xaml
    /// </summary>
    public partial class ReserveAccommodationView : Window
    {
        public DateOnly ReservationStart {  get; set; }
        public DateOnly ReservationEnd {  get; set; }
        public List<DateOnly> StartCandidates { get; set; }
        public List<DateOnly> EndCandidates { get; set; }
        private AccommodationReservationRepository ReservationRepository { get; set; }
        public List<AccommodationReservation> PreviousReservations {  get; set; }
        public ReserveAccommodationView(AccommodationDTO accommodation)
        {
            InitializeComponent();
            StartCandidates = new List<DateOnly>();
            EndCandidates = new List<DateOnly>();
            ReservationRepository = new AccommodationReservationRepository();
            PreviousReservations = ReservationRepository.GetAll();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            DateOnly startDate = DateOnly.Parse(StartDateTextBox.Text);
            DateTime start = startDate.ToDateTime(TimeOnly.Parse("10:00PM"));
            DateOnly endDate = DateOnly.Parse(EndDateTextBox.Text);
            DateTime end = endDate.ToDateTime(TimeOnly.Parse("10:00PM"));
            if (start > end) 
            {
                MessageBox.Show("End Date needs to be bigger then start date");            
            }
            else
            {
                int lengthOfStay = Convert.ToInt32(StayLengthTextBox.Text);
                TimeSpan unavailablePeriod = start.AddDays(lengthOfStay) - start;
                if (!FindDatesInRange(start, end, lengthOfStay, unavailablePeriod))
                {
                    start = end.Subtract(unavailablePeriod);
                    FindDatesOutRange(start, lengthOfStay, unavailablePeriod);
                }

            }
            

        }

        private bool FindDatesInRange(DateTime start, DateTime end, int length, TimeSpan period)
        {
            DateTime[] datesBetween = Enumerable.Range(0, 1 + end.Subtract(start).Days).Select(offset => start.AddDays(offset)).ToArray();
            bool notFree = false;
            while (start != end.Subtract(period))
            {
                foreach(AccommodationReservation reservation in PreviousReservations)
                {
                    if((start <= (Convert.ToDateTime(reservation.EndDate)) || (start.AddDays(length)) >= (Convert.ToDateTime(reservation.StartDate))))
                    {
                        notFree = true; 
                        break;
                    }
                }
                if(!notFree)
                {
                    StartCandidates.Add(DateOnly.FromDateTime(start));
                    EndCandidates.Add(DateOnly.FromDateTime(end));
                }
                notFree= false;
                start = start.AddDays(1);
            }
            return StartCandidates.Count > 0;
        }
        private void FindDatesOutRange(DateTime start, int length, TimeSpan unavailablePeriod)
        {
            while(StartCandidates.Count < 5)
            {
                DateTime endDate = start.AddDays(30);
                FindDatesInRange(start, endDate, length, unavailablePeriod);
                start = endDate.Subtract(unavailablePeriod);
            }
            if(StartCandidates.Count > 5) {
                StartCandidates.RemoveRange(5, StartCandidates.Count - 5);
                EndCandidates.RemoveRange(5, EndCandidates.Count - 5);
            }
            
        }

    }
}
