using BookingApp.Model;
using BookingApp.Repository;
using BookingApp.View.Guest;
using BookingApp.View.Guide;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for SignInForm.xaml
    /// </summary>
    public partial class SignInForm : Window
    {

        private readonly UserRepository _repository;

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SignInForm()
        {
            InitializeComponent();
            DataContext = this;
            _repository = new UserRepository();
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            User User = _repository.GetByUsername(Username);
            if (User != null)
            {
                if(User.Password == txtPassword.Password)
                {
                    if(User.Type == Enumeration.UserType.Guest)
                    {
                        GuestMainView guestMainView = new GuestMainView(User);
                        guestMainView.ShowDialog();
                    }
                    else if(User.Type == Enumeration.UserType.Guide)
                    {
                        GuideMainView guideMainView = new GuideMainView();
                        guideMainView.ShowDialog();
                    }
                } 
                else
                {
                    MessageBox.Show("Wrong password!");
                }
            }
            else
            {
                MessageBox.Show("Wrong username!");
            }
            
        }
    }
}
