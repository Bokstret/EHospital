using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.SQLite;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace eHospital
{
	public enum Humans
	{
		Patient,
		Nurse,
		Doctor
	}

	interface IDoctor
	{
		void TakePatient(Patient patient);
		void DiscardPatient(Patient patient);
	}


	interface IDatabaseCommutable
	{
		void LoadFromDb(int uniqueId);

		void SaveToDb();
	}


	public abstract class Human
	{
		public string Name { get; set; }

		public DateTime Birthdate { get ; set; }

		public int Id { get; set; }
	}





	public class Patient : Human, IDatabaseCommutable
	{
		public string Diseases { get; set; }

		public int Curator_doctor { get; set; }

		public string Info { get; set; }

		public int Status { get; set; }

		public int Treat_id { get; set; }

		public int Room_number { get; set; }

		void IDatabaseCommutable.LoadFromDb(int uniqueId)
		{
			string query = "SELECT room_num, treat_id, status, curator_doctor, name, diseases, info, birthdate FROM PATIENT where id = @patId";

			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "patId", uniqueId }
			};

			Dictionary<int, object> reader = DBConnector.queryExecuteSingleResult(query, parameters);

			Id = uniqueId;
			Room_number = Convert.ToInt32(reader[0]);
			Treat_id = Convert.ToInt32(reader[1]);
			Status = Convert.ToInt32(reader[2]);
			object result = reader[3];
			result = (result == DBNull.Value) ? null : result;
			Curator_doctor = Convert.ToInt32(result);
			Name = Convert.ToString(reader[4]);
			Diseases = Convert.ToString(reader[5]);
			Info = Convert.ToString(reader[6]);
			Birthdate = Convert.ToDateTime(reader[7]);
		}

		void IDatabaseCommutable.SaveToDb()
		{
			string query = @"UPDATE Patient SET room_num = @room, treat_id = @treat, status = @status, curator_doctor = @curator, name = @name, 
							diseases = @diseases, info = @info, birthdate = @birthdate WHERE id = @patId";

			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "room", Room_number },
				{ "treat", Treat_id },
				{ "status", Status },
				{ "curator", Curator_doctor },
				{ "name", Name },
				{ "diseases", Diseases },
				{ "info", Info },
				{ "birthdate", Birthdate },
				{ "patId", Id }
			};

			DBConnector.queryExecuteSingleResult(query, parameters);
		}
	}



	public class Nurse : Human, IDatabaseCommutable, IDoctor
	{
		public ObservableCollection<Patient> Patients { get; set; }

		public int Cabinet { get; set; }

		public virtual Human CreateNewHuman(Dictionary<string, object> parameters, Humans human_type = Humans.Patient)
		{
			// Nurse and Doctor can create only patients (ADD TRY CATCH LATER!)
			string query = "SELECT seq FROM sqlite_sequence WHERE name = 'Patient'";

			Dictionary<int, object> reader = DBConnector.queryExecuteSingleResult(query);

			query = @"INSERT INTO Patient (id, room_num, treat_id, status, curator_doctor, name,  diseases, info, birthdate)
					VALUES (@patId, @room, @treat, @status, @curator, @name, @diseases, @info, @birthdate)";

			int newPatId = Convert.ToInt32(reader[0]) + 1;
			parameters.Add("patId", newPatId);
			parameters.Add("status", 0);
			parameters.Add("curator", Id);
			parameters.Add("treat", 1);

			DBConnector.queryExecuteSingleResult(query, parameters);

			Patient patient = new Patient();
			((IDatabaseCommutable)patient).LoadFromDb(newPatId);

			return patient;
		}


		void IDatabaseCommutable.LoadFromDb(int uniqueId)
		{
			string query = "SELECT name, cabinet_num, birthdate, retired FROM Worker WHERE id = @docId";

			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "docId", uniqueId }
			};

			Dictionary<int, object> reader = DBConnector.queryExecuteSingleResult(query, parameters);

			if (Convert.ToInt32(reader[3]) != 0)
			{
				throw new HaveBeenFiredException("You have been fired :(");
			}

			Id = uniqueId;
			this.Name = Convert.ToString(reader[0]);
			this.Cabinet = Convert.ToInt32(reader[1]);
			this.Birthdate = Convert.ToDateTime(reader[2]);
			this.Patients = PatientLoader.LoadByDoctorId(uniqueId);
		}

		void IDatabaseCommutable.SaveToDb()
		{
			string query = "UPDATE Worker SET name = @name, cabinet_num = @cabNum, post = 0, retired = 0,  birthdate = @birthdate WHERE id = @docId";

			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "name", Name },
				{ "cabNum", Cabinet },
				{ "birthdate", Birthdate },
				{ "docId", Id }
			};

			DBConnector.queryExecuteSingleResult(query, parameters);
		}


		void IDoctor.TakePatient(Patient patient)
		{
			Patients.Add(patient);

			string query = "INSERT OR REPLACE INTO Doctor_Patient (doctor_id, patient_id) VALUES (@docId, @patId)";

			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "docId", Id },
				{ "patId",patient.Id }
			};

			DBConnector.queryExecuteSingleResult(query, parameters);
		}

		void IDoctor.DiscardPatient(Patient patient)
		{
			string query = "DELETE FROM Doctor_Patient WHERE doctor_id = @docId and patient_id = @patId";

			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "docId", Id },
				{ "patId",patient.Id }
			};

			DBConnector.queryExecuteSingleResult(query, parameters);

			Patients.Remove(patient);
		}
	}


	public class Doctor: Nurse, IDatabaseCommutable, IDoctor
	{
		void IDatabaseCommutable.SaveToDb()
		{
			string query = "UPDATE Worker SET name = @name, cabinet_num = @cabNum, post = 1, retired = 0,  birthdate = @birthdate WHERE id = @docId";

			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "name", Name },
				{ "cabNum", Cabinet },
				{ "birthdate", Birthdate },
				{ "docId", Id }
			};

			DBConnector.queryExecuteSingleResult(query, parameters);
		}

		public void WriteOutPatient(Patient patient)
		{
			patient.Status = 1;
			((IDatabaseCommutable)patient).SaveToDb();

			string query = "DELETE FROM Doctor_Patient WHERE patient_id = @patId";

			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "patId", patient.Id }
			};

			DBConnector.queryExecuteSingleResult(query, parameters);

			Patients.Remove(patient);
		}
	}



	public class HeadPhysician: Doctor, IDatabaseCommutable, IDoctor
	{
		void IDatabaseCommutable.SaveToDb()
		{
			string query = "UPDATE Worker SET name = @name, cabinet_num = @cabNum, post = 2, retired = 0,  birthdate = @birthdate WHERE id = @docId";

			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "name", Name },
				{ "cabNum", Cabinet },
				{ "birthdate", Birthdate },
				{ "docId", Id }
			};

			DBConnector.queryExecuteSingleResult(query, parameters);
		}


		public void DismissDoctor(Nurse docToDelete)
		{
			if (docToDelete is HeadPhysician)
				throw new Exception("YOU CAN'T DELETE HEAD PHYSICIAN AYAYAYA");
			
			string query = "UPDATE Worker SET retired = 1 WHERE id = @docId";

			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "docId", docToDelete.Id }
			};

			DBConnector.queryExecuteSingleResult(query, parameters);
		}

		public override Human CreateNewHuman(Dictionary<string, object> parameters, Humans human_type = Humans.Patient)
		{
			// Head Phys can create empty Nurse (case = 1), Doctor (case = 2) and Patient (default)
			if (human_type == Humans.Patient)
			{
				string query = "SELECT seq FROM sqlite_sequence WHERE name = 'Patient'";

				Dictionary<int, object> reader = DBConnector.queryExecuteSingleResult(query);

				query = @"INSERT INTO Patient (id, room_num, treat_id, status, curator_doctor, name,  diseases, info, birthdate)
					VALUES (@patId, @room, @treat, @status, @curator, @name, @diseases, @info, @birthdate)";

				int newPatId = Convert.ToInt32(reader[0]) + 1;
				parameters.Add("patId", newPatId);
				parameters.Add("status", 0);
				parameters.Add("curator", Id);
				parameters.Add("treat", 1);

				DBConnector.queryExecuteSingleResult(query, parameters);

				Patient patient = new Patient();
				((IDatabaseCommutable)patient).LoadFromDb(newPatId);

				return patient;
			}
			else
			{
				string query = "SELECT seq FROM sqlite_sequence WHERE name = 'Worker'";

				Dictionary<int, object> reader = DBConnector.queryExecuteSingleResult(query);

				query = @"INSERT INTO Worker (id, password, name, cabinet_num, post, retired, birthdate)
						VALUES (@docId, @password, @name, @cabinet, @post, 0, @birthdate)";

				int newDocId = Convert.ToInt32(reader[0]) + 1;
				parameters.Add("docId", newDocId);

				Nurse newDoctor;

				if (human_type == Humans.Doctor)
				{
					parameters.Add("post", 1);
					newDoctor = new Doctor();
				}
				else
				{
					parameters.Add("post", 0);
					newDoctor = new Nurse();
				}

				DBConnector.queryExecuteSingleResult(query, parameters);

				((IDatabaseCommutable)newDoctor).LoadFromDb(newDocId);

				return newDoctor;
			}
		}
	}
}

