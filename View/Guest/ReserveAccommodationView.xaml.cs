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
        public Accommodation SelectedAccommodation { get; set; }
        public User Guest {  get; set; }
        public ReserveAccommodationView(AccommodationDTO accommodation, User user)
        {
            InitializeComponent();
            StartCandidates = new List<DateOnly>();
            EndCandidates = new List<DateOnly>();
            ReservationRepository = new AccommodationReservationRepository();
           
            SelectedAccommodation = accommodation.ToAccommodation();
            Guest = user;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            StartCandidates.Clear();
            EndCandidates.Clear();
            PreviousReservations = ReservationRepository.GetByAccommodation(SelectedAccommodation);
            DateOnly startDate = DateOnly.Parse(StartDateTextBox.Text);
            DateTime start = startDate.ToDateTime(TimeOnly.Parse("10:00PM"));
            DateOnly endDate = DateOnly.Parse(EndDateTextBox.Text);
            DateTime end = endDate.ToDateTime(TimeOnly.Parse("10:00PM"));
            int length = Convert.ToInt32(StayLengthTextBox.Text);
            string message;
            if(CheckUserInput(start, end, length))
            {
                TimeSpan unavailablePeriod = start.AddDays(length) - start;
                if (!FindFreeDatesInRange(start, end, length, unavailablePeriod))
                {
                    MessageBox.Show("Nisam nasao  u range");
                    FindDatesOutRange(start, end, length, unavailablePeriod);
                    message = "No Available Dates in the period you chose, here are some other free dates outside the period you chose";
                }
                else
                {
                    message = "Here are all available dates.";
                }
                AvailableReservationDatesView availableReservationDatesView = new AvailableReservationDatesView(message, StartCandidates, EndCandidates, Guest.Id, SelectedAccommodation.Id);
                availableReservationDatesView.ShowDialog();
                if(availableReservationDatesView.isChosen)
                {
                    ReservationRepository.Save(new AccommodationReservation(SelectedAccommodation, Guest, availableReservationDatesView.ChosenStart, availableReservationDatesView.ChosenEnd));
                }
            }

        }

        private bool FindFreeDatesInRange(DateTime start, DateTime end, int length, TimeSpan period)
        {
            //DateTime[] datesBetween = Enumerable.Range(0, 1 + end.Subtract(start).Days).Select(offset => start.AddDays(offset)).ToArray();
            bool notFree = false;
            while (start != end.Subtract(period).AddDays(1))
            {
                foreach(AccommodationReservation reservation in PreviousReservations)
                {
                    
                    notFree = IsDateFree(start, end, length, reservation);
                    if (notFree)
                    {
                        break;
                    }
                }
                if(!notFree)
                {
                    StartCandidates.Add(DateOnly.FromDateTime(start));
                    EndCandidates.Add(DateOnly.FromDateTime(start.AddDays(length)));
                }
                notFree= false;
                start = start.AddDays(1);
            }
            if(StartCandidates.Count > 10)
            {
                StartCandidates.RemoveRange(10, StartCandidates.Count - 10);
                EndCandidates.RemoveRange(10, EndCandidates.Count - 10);
            }
            return StartCandidates.Count > 0;
        }
        private void FindDatesOutRange(DateTime start,DateTime end, int length, TimeSpan unavailablePeriod)
        {
            //if((start - DateTime.Now).Days > length)
            //{
            //    FindFreeDatesInRange(DateTime.Now, start, length, unavailablePeriod);
            //    start = end.Subtract(unavailablePeriod);
            //}
            
            while (StartCandidates.Count < 5)
            {
                //DateTime endDate = start.AddDays(30);
                MessageBox.Show("Trazim van");
                bool x = FindFreeDatesInRange(start, start.AddDays(20), length, unavailablePeriod);
                start = start.AddDays(20 - length);
            }
            if(StartCandidates.Count > 5) {
                StartCandidates.RemoveRange(5, StartCandidates.Count - 5);
                EndCandidates.RemoveRange(5, EndCandidates.Count - 5);
            }
            
        }
        private bool CheckUserInput(DateTime start,  DateTime end, int length)
        {
            if (start > end )
            {
                MessageBox.Show("End Date needs to be bigger then start date");
                return false;
            }
            if(length > (end - start).Days )
            {
                MessageBox.Show("Length of stay too long for selected days");
                return false;
            }
            if(length < SelectedAccommodation.MinReservationDays)
            {
                MessageBox.Show("Length of stay too short, needs to be at least" + SelectedAccommodation.MinReservationDays.ToString() + "days");
                return false;
            }
            return true;
        }
        private bool IsDateFree(DateTime start, DateTime end, int length, AccommodationReservation reservation)
        {
            if (start <= reservation.EndDate.ToDateTime(TimeOnly.Parse("10:00PM")) && start >= reservation.StartDate.ToDateTime(TimeOnly.Parse("10:00PM")))
            {
                return true;
                
            }
            else if (start.AddDays(length) >= reservation.StartDate.ToDateTime(TimeOnly.Parse("10:00PM")) && start.AddDays(length) <= reservation.EndDate.ToDateTime(TimeOnly.Parse("10:00PM")))
            {
                return true;
                
            }
            else if (start <= reservation.StartDate.ToDateTime(TimeOnly.Parse("10:00PM")) && start.AddDays(length) >= reservation.EndDate.ToDateTime(TimeOnly.Parse("10:00PM")))
            {
                return true;
               
            }
            return false;
        }
    }
}
