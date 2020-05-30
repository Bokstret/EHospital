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
    /// Логика взаимодействия для WorkingWindow.xaml
    /// </summary>
    public partial class WorkingWindow : Window
    {
        Nurse sessionDoctor;

        public WorkingWindow(Nurse sessionDoctor)
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.sessionDoctor = sessionDoctor;
            doctorName.Text = sessionDoctor.Name;

            FramePanel.Content = new PageMe(sessionDoctor);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
        }

        private void meButton_Click(object sender, RoutedEventArgs e)
        {
            FramePanel.Content = new PageMe(sessionDoctor);
        }

        private void patientsButton_Click(object sender, RoutedEventArgs e)
        {
            FramePanel.Content = new PagePatients(sessionDoctor, this);
        }

        private void doctorsButton_Click(object sender, RoutedEventArgs e)
        {
            FramePanel.Content = new PageDoctors(sessionDoctor, this);
        }

        private void treatmentButton_Click(object sender, RoutedEventArgs e)
        {
            FramePanel.Content = new PageTreatment();
        }
    }
}
