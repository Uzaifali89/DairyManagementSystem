using DairyManagementSystem.Forms;
using DMS.EntitesModel.Users;
using DMS.Services;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DairyManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUserService _userService;
        public MainWindow(IUserService userService) 
        {
            _userService = userService;
            InitializeComponent();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textEmail.Text) && txtEmail.Text.Length > 0)
            {
               
                textEmail.Visibility = Visibility.Collapsed;
            }
            else
            {
                textEmail.Visibility = Visibility.Visible;
            }
          
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text) && txtPassword.Text.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
           
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtPassword.Text))
                MessageBox.Show("Please enter email or password.");
            else
            {
                AuthenticateRequest auth = new AuthenticateRequest();
                auth.Email = txtEmail.Text;
                auth.Password = txtPassword.Text;
                var user = _userService.Authenticate(auth, "");
                if (user != null)
                {
                    MessageBox.Show("Login successfull");

                    Master window = new Master();
                    window.Show();
                    this.Close();
                }
            }
       
            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}