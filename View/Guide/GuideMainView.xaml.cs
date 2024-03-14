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

namespace BookingApp.View.Guide
{
    /// <summary>
    /// Interaction logic for GuideMainView.xaml
    /// </summary>
    public partial class GuideMainView : Window
    {
        public GuideMainView()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            // Otvaranje novog prozora ili dijaloga
            CreateTour newWindow = new CreateTour();
            newWindow.Show();
        }
    }
}
