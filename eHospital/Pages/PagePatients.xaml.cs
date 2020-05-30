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
    /// Логика взаимодействия для PagePatients.xaml
    /// </summary>
    public partial class PagePatients : Page
    {
        Nurse currentDoc;
        WorkingWindow window;
        public PagePatients(Nurse sessionDoctor, WorkingWindow window)
        {
            InitializeComponent();

            this.currentDoc = sessionDoctor;

            this.window = window;

            this.DataContext = new PatientViewModel(sessionDoctor);
        }

        private void createNewPat_Click(object sender, RoutedEventArgs e)
        {
            NewPatientWindow newPatientWindow = new NewPatientWindow(this.currentDoc, this.window);
            newPatientWindow.ShowDialog();
        }
    }
}
