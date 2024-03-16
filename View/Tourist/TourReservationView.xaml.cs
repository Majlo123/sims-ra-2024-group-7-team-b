using BookingApp.DTO;
using System;
using System.IO;
using System.Windows;

namespace BookingApp.View.Tourist
{
    public partial class TourReservationView : Window
    {
        private TourDTO SelectedTour { get; set; }
        private string csvFilePath = "../../../Resources/Data/tour.csv";

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

            MessageBox.Show($"Tour successfully reserved for {numberOfGuests} guests!");

            SelectedTour.MaxGuests -= numberOfGuests;
            UpdateCsvFile(SelectedTour.Id, SelectedTour.MaxGuests);

            this.Close();
        }

        private void UpdateCsvFile(int tourId, int newMaxGuests)
        {
            string tempFile = Path.GetTempFileName();
            using (var reader = new StreamReader(csvFilePath))
            using (var writer = new StreamWriter(tempFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    
                    
                        if (parts[0] == tourId.ToString())
                        {
                            parts[5] = newMaxGuests.ToString();
                            line = string.Join("|", parts);
                        }
                    
                    writer.WriteLine(line);
                }
            }
            File.Delete(csvFilePath);
            File.Move(tempFile, csvFilePath);
        }
    }
}
