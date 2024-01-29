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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BayenSolutions.Forms.Windows
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textUsername_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtUsername.Focus();
        }

        private void textUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(textUsername.Text) && textUsername.Text.Length > 0)
            {
                textUsername.Visibility = Visibility.Collapsed;
            }
            else
            {
                textUsername.Visibility=Visibility.Visible;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void textPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility=Visibility.Visible;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (IsValidCredentials(username, password))
            {
                //MessageBox.Show("Successfully Logged!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Your username or password is not valid!");
            }
        }

        private bool IsValidCredentials(string username, string password)
        {
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }
    }
}
