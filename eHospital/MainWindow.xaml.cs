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

using System.Data.SQLite;
using System.IO;
using System.Drawing;
using System.Diagnostics;


namespace eHospital
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void LoginField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginField.Text == "Login")
                LoginField.Text = "";
            wrongDataText.Visibility = Visibility.Collapsed;
            LoginField.Foreground = Brushes.DarkGray;
            PasswordField.Foreground = Brushes.DarkGray;
        }

        private void LoginField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginField.Text))
                LoginField.Text = "Login";
        }

        private void PasswordField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordField.Password == "Password")
                PasswordField.Password = "";
            wrongDataText.Visibility = Visibility.Collapsed;
            LoginField.Foreground = Brushes.DarkGray;
            PasswordField.Foreground = Brushes.DarkGray;
        }

        private void PasswordField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordField.Password))
                PasswordField.Password = "Password";
        }

        private void CloseButton_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoginFunction(object sender, RoutedEventArgs e)
        {
            string login = LoginField.Text;
            string password = PasswordField.Password;

            string query = "SELECT password, retired, post from Worker where cast(id as TEXT) = @login";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "login", login }
            };

            Dictionary<int, object> reader = DBConnector.queryExecuteSingleResult(query, parameters);

            if (reader.Count != 0 && password == Convert.ToString(reader[0]) && Convert.ToInt32(reader[1]) == 0)
            {
                int post = Convert.ToInt32(reader[2]);
                Nurse sessionDoctor;
                if (post == 1)
                {
                    sessionDoctor = new Doctor();
                }
                else if (post == 2)
                {
                    sessionDoctor = new HeadPhysician();
                }
                else
                {
                    sessionDoctor = new Nurse();
                }
                ((IDatabaseCommutable)sessionDoctor).LoadFromDb(Int32.Parse(login));
                WorkingWindow workingWindow = new WorkingWindow(sessionDoctor);
                workingWindow.Show();
                this.Close();
            } 
            else
            {
                wrongDataText.Visibility = Visibility.Visible;
                LoginField.Foreground = Brushes.Red;
                PasswordField.Foreground = Brushes.Red;
            }
        }
    }
}
