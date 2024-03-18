using BookingApp.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace BookingApp.View.Tourist
{
    public partial class TourReservationView : Window
    {
        private TourDTO SelectedTour { get; set; }
       

        public TourReservationView(TourDTO selectedTour)
        {
            InitializeComponent();
            SelectedTour = selectedTour;

            TextBoxGuests.Text = SelectedTour.MaxGuests.ToString();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ReserveClick(object sender, RoutedEventArgs e)
        {
            int numberOfGuests;
            if (!int.TryParse(TextBoxGuests.Text, out numberOfGuests) || numberOfGuests <= 0)
            {
                MessageBox.Show("Please enter a valid positive number of guests.");
                return;
            }

            if (numberOfGuests > SelectedTour.MaxGuests)
            {
                MessageBox.Show("There are not enough available seats for the selected number of guests.");
                return;
            }

            List<string> guestNames = new List<string>();
            for (int i = 0; i < numberOfGuests; i++)
            {
                guestNames.Add("Guest " + (i + 1)); // Primer imena gosta
            }

            PeopleReportWindow peopleReportWindow = new PeopleReportWindow(guestNames,SelectedTour);
            peopleReportWindow.ShowDialog();

            this.Close();
        }

    }
}
