using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace eHospital
{
    class PatientLoader
    {
		
		public static ObservableCollection<Patient> LoadAll()
        {
			string query = "SELECT id FROM PATIENT WHERE status = 0";

			List<Dictionary<int, object>> patientsDB = DBConnector.queryExecuteMultiResult(query);

			ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

			foreach (Dictionary<int, object> data in patientsDB)
			{
				Patient patient = new Patient();
				((IDatabaseCommutable)patient).LoadFromDb(Convert.ToInt32(data[0]));
				patients.Insert(0, patient);
			}

			return patients;
		}

		public static ObservableCollection<Patient> LoadByDoctorId(int doctorId)
		{
			string query = "SELECT patient_id FROM Doctor_Patient WHERE doctor_id = @docId";

			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "docId", doctorId }
			};

			List<Dictionary<int, object>> patientsDB = DBConnector.queryExecuteMultiResult(query, parameters);

			ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

			foreach (Dictionary<int, object> data in patientsDB)
			{
				Patient patient = new Patient();
				((IDatabaseCommutable)patient).LoadFromDb(Convert.ToInt32(data[0]));
				patients.Add(patient);
			}

			return patients;
		}


		// -------------------------- PART FOR DOCTORS AND OTHERS

		public static ObservableCollection<Nurse> LoadNurses()
		{
			string query = "SELECT id FROM Worker WHERE retired = 0 and post = 0";

			List<Dictionary<int, object>> doctorsDB = DBConnector.queryExecuteMultiResult(query);

			ObservableCollection<Nurse> doctors = new ObservableCollection<Nurse>();

			foreach (Dictionary<int, object> data in doctorsDB)
			{
				Nurse nurse = new Nurse();
				((IDatabaseCommutable)nurse).LoadFromDb(Convert.ToInt32(data[0]));
				doctors.Add(nurse);
			}

			return doctors;
		}

		public static ObservableCollection<Doctor> LoadDoctors()
		{
			string query = "SELECT id FROM Worker WHERE retired = 0 and post = 1";

			List<Dictionary<int, object>> doctorsDB = DBConnector.queryExecuteMultiResult(query);

			ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();

			foreach (Dictionary<int, object> data in doctorsDB)
			{
				Doctor doc = new Doctor();
				((IDatabaseCommutable)doc).LoadFromDb(Convert.ToInt32(data[0]));
				doctors.Add(doc);
			}

			return doctors;
		}


		public static ObservableCollection<HeadPhysician> LoadHeadPhyses()
		{
			string query = "SELECT id FROM Worker WHERE retired = 0 and post = 2";

			List<Dictionary<int, object>> doctorsDB = DBConnector.queryExecuteMultiResult(query);

			ObservableCollection<HeadPhysician> doctors = new ObservableCollection<HeadPhysician>();

			foreach (Dictionary<int, object> data in doctorsDB)
			{
				HeadPhysician headPhysician = new HeadPhysician();
				((IDatabaseCommutable)headPhysician).LoadFromDb(Convert.ToInt32(data[0]));
				doctors.Add(headPhysician);
			}

			return doctors;
		}
	}
}
