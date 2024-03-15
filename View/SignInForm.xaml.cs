using BookingApp.Model;
using BookingApp.Repository;
using BookingApp.View.Guest;

using BookingApp.View.Owner;
using BookingApp.View.Guide;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using BookingApp.View.Tourist;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for SignInForm.xaml
    /// </summary>
    public partial class SignInForm : Window
    {
        public User User { get; set; }
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
            User = new User();
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            User = _repository.GetByUsername(Username);
            if (User != null)
            {
                if(User.Password == txtPassword.Password)
                {
                    if(User.Type == Enumeration.UserType.Guest)
                    {
                        GuestMainView guestMainView = new GuestMainView();
                        guestMainView.ShowDialog();
                    }


                    if (User.Type == Enumeration.UserType.Owner)
                    {
                        OwnerMainView ownerMainView = new OwnerMainView(User);
                        ownerMainView.ShowDialog();
                    }
                    else if (User.Type == Enumeration.UserType.Guide)

                    if (user.Type == Enumeration.UserType.Owner)
                    {
                        OwnerMainView ownerMainView = new OwnerMainView();
                        ownerMainView.ShowDialog();
                    }
                    if(user.Type == Enumeration.UserType.Guide)

                    {
                        GuideMainView guideMainView = new GuideMainView();
                        guideMainView.ShowDialog();
                    }
                    if(user.Type == Enumeration.UserType.Tourist) { 
                        TouristMainView touristMainView = new TouristMainView();
                            touristMainView.ShowDialog();
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
    
