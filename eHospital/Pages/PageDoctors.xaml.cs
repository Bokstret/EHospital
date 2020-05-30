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

namespace eHospital.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageDoctors.xaml
    /// </summary>
    public partial class PageDoctors : Page
    {
        Nurse currentDoc;
        WorkingWindow window;
        public PageDoctors(Nurse sessionDoctor, WorkingWindow window)
        {
            InitializeComponent();

            this.currentDoc = sessionDoctor;

            this.window = window;

            this.DataContext = new DoctorsViewModel(sessionDoctor);

            if (sessionDoctor is HeadPhysician)
                newDoctorPanel.Visibility = Visibility.Visible;
        }

        private void createNewDoctorBtn_Click(object sender, RoutedEventArgs e)
        {
            NewDoctorWindow newDoctorWindow = new NewDoctorWindow(this.currentDoc as HeadPhysician, this.window);
            newDoctorWindow.ShowDialog();
        }
    }
}
