using eHospital.Pages;
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

namespace eHospital
{
    /// <summary>
    /// Логика взаимодействия для NewPatientWindow.xaml
    /// </summary>
    public partial class NewPatientWindow : Window
    {
        WorkingWindow window;
        Nurse sessionDoctor;
        public NewPatientWindow(Nurse sessionDoctor, WorkingWindow window)
        {
            InitializeComponent();

            this.window = window;

            this.sessionDoctor = sessionDoctor;

            NewPatViewModel viewModel = new NewPatViewModel(sessionDoctor);

            this.DataContext = viewModel;

            viewModel.addNewPatCompleted += AddNewPatView;
        }

        private void extBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void patRoomNumField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(patRoomNumField.Text, out _))
            {
                patRoomNumField.Text = "0";
            }
        }

        private void patBirthField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(patBirthField.Text, out _))
            {
                patBirthField.Text = Convert.ToString(new DateTime(2000, 1, 1));
            }
        }

        private void AddNewPatView()
        {
            window.FramePanel.Content = new PagePatients(this.sessionDoctor, this.window);

            this.Close();
        }
    }
}
