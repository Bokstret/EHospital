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
    /// Логика взаимодействия для NewDoctorWindow.xaml
    /// </summary>
    public partial class NewDoctorWindow : Window
    {
        WorkingWindow window;
        HeadPhysician sessionDoctor;
        public NewDoctorWindow(HeadPhysician sessionDoctor, WorkingWindow window)
        {
            InitializeComponent();

            this.window = window;

            this.sessionDoctor = sessionDoctor;

            NewDocViewModel viewModel = new NewDocViewModel(sessionDoctor);

            this.DataContext = viewModel;

            viewModel.addDocCompleted += AddNewDocView;
        }

        private void extBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void docBirthField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(docBirthField.Text, out _))
            {
                docBirthField.Text = Convert.ToString(new DateTime(2000, 1, 1));
            }
        }

        private void docCabinetField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(docCabinetField.Text, out _))
            {
                docCabinetField.Text = "0";
            }
        }

        private void AddNewDocView()
        {
            window.FramePanel.Content = new PageDoctors(this.sessionDoctor, this.window);

            this.Close();
        }
    }
}
