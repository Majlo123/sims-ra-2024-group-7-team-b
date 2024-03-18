using BookingApp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace BookingApp.View.Tourist
{
    public partial class PeopleReportWindow : Window, INotifyPropertyChanged
    {
        public event EventHandler<List<string>> GuestDataUpdated;
        public event PropertyChangedEventHandler PropertyChanged;
        private List<string> guestNames;
        private int currentGuestIndex = 0;
        private TourDTO SelectedTour { get; set; }
        private string csvFilePath = "../../../Resources/Data/tour.csv";
        private string currentGuestLabel;
        public string CurrentGuestLabel
        {
            get { return currentGuestLabel; }
            set
            {
                if (currentGuestLabel != value)
                {
                    currentGuestLabel = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentGuestLabel"));
                }
            }
        }

        public PeopleReportWindow(List<string> guests, TourDTO selectedTour)
        {
            InitializeComponent();
            guestNames = guests;
            SelectedTour = selectedTour;
            ResetTextBoxes();
            DisplayCurrentGuestData();
        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            SaveCurrentGuestData();

            currentGuestIndex++;
            if (currentGuestIndex >= guestNames.Count)
            {
                MessageBox.Show("All guests have been reviewed.");
                GuestDataUpdated?.Invoke(this, guestNames);
                UpdateTourCapacity();
                Close();
                return;
            }

            DisplayCurrentGuestData();
        }

        private void PreviousClick(object sender, RoutedEventArgs e)
        {
            SaveCurrentGuestData();

            currentGuestIndex--;
            if (currentGuestIndex < 0)
            {
                MessageBox.Show("You are already on the first guest.");
                return;
            }

            DisplayCurrentGuestData();
        }

        private void SaveCurrentGuestData()
        {
            if (currentGuestIndex < guestNames.Count)
            {
                string fullName = $"{TextBoxFirstName.Text} {TextBoxLastName.Text}";
                string age = TextBoxAge.Text;
                guestNames[currentGuestIndex] = $"{fullName}, Age: {age}";
            }
        }

        private void DisplayCurrentGuestData()
        {
            if (currentGuestIndex < guestNames.Count)
            {
                string[] parts = guestNames[currentGuestIndex].Split(',');
                if (parts.Length >= 2 && parts[1].Contains(":"))
                {
                    string[] nameParts = parts[0].Split(' ');
                    TextBoxFirstName.Text = nameParts.Length > 0 ? nameParts[0] : "";
                    TextBoxLastName.Text = nameParts.Length > 1 ? nameParts[1] : "";
                    TextBoxAge.Text = parts[1].Split(':')[1].Trim();
                    CurrentGuestLabel = $"Guest {currentGuestIndex + 1}";
                }
                else
                {
                    ResetTextBoxes();
                }
            }
            else
            {
                ResetTextBoxes();
            }

        }

        private void ResetTextBoxes()
        {
            CurrentGuestLabel = $"Guest {currentGuestIndex + 1}";
            TextBoxFirstName.Text = "";
            TextBoxLastName.Text = "";
            TextBoxAge.Text = "";
        }

        private void UpdateTourCapacity()
        {
            SelectedTour.MaxGuests -= guestNames.Count;
            UpdateCsvFile(SelectedTour.Id, SelectedTour.MaxGuests);
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
            ReplaceCsvFile(tempFile);
        }

        private void ReplaceCsvFile(string tempFile)
        {
            File.Delete(csvFilePath);
            File.Move(tempFile, csvFilePath);
        }
    }
}
