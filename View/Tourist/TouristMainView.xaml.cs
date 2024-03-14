﻿using BookingApp.DTO;
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

namespace BookingApp.View.Tourist
{
    /// <summary>
    /// Interaction logic for TouristMainView.xaml
    /// </summary>
    public partial class TouristMainView : Window
    {
        public TourDTO SelectedTour { get; set; }

        
        public ObservableCollection<Tour> Tours { get; set; }
        public ObservableCollection<Tour> FilteredTours { get; set; }

        public TourRepository TourRepository;

        public TouristMainView()
        {
            DataContext = this;
            TourRepository = new TourRepository();
            Tours = new ObservableCollection<Tour>(TourRepository.GetAll());

            FilteredTours = new ObservableCollection<Tour>();

            InitializeComponent();
        }

       
        private void SearchClick(object sender, RoutedEventArgs e)
            {
                
                string location = TextBoxLocation.Text.Trim();
                string duration = TextBoxDuration.Text.Trim();
                string language = TextBoxLanguage.Text.Trim();
                int numGuests = 0;
                int.TryParse(TextBoxNumGuest.Text.Trim(), out numGuests);

                
                FilteredTours.Clear();
                foreach (var tour in Tours)
                {
                    
                    if (!string.IsNullOrEmpty(location) &&
                        !tour.Location.ToString().ToLower().Contains(location.ToLower()))
                    {
                        continue; 
                    }

                    
                    if (!string.IsNullOrEmpty(duration) &&
                        tour.Duration.ToString() != duration)
                    {
                        continue; 
                    }

                    
                    if (!string.IsNullOrEmpty(language) &&
                        !tour.Language.ToString().ToLower().Contains(language.ToLower()))
                    {
                        continue; 
                    }

                    
                    if (numGuests > 0 && numGuests > tour.MaxGuests)
                    {
                        continue; 
                    }

                    
                    FilteredTours.Add(tour);
                }

               
                Table.ItemsSource = FilteredTours;
            }
       
        private void ReserveClick(object sender, RoutedEventArgs e)
        {
            if (SelectedTour != null)
            {
                
                
            }
            else
            {
                MessageBox.Show("Please select a tour before making a reservation.");
            }
        }

        
    }
}
