using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace eHospital
{
    class MeViewModel
    {
        private Command writeOutPat;
        public Command WriteOutPat
        {
            get
            {
                return writeOutPat ??
                    (writeOutPat = new Command(obj =>
                    {
                        Patient patient = obj as Patient;
                        Doctor doctor = CurrentDoc as Doctor;
                        doctor.WriteOutPatient(patient);
                    },
                    (obj) => CurrentDoc is Doctor | CurrentDoc is HeadPhysician));
            }
        }


        private Command discardPat;
        public Command DiscardPat
        {
            get
            {
                return discardPat ??
                    (discardPat = new Command(obj =>
                    {
                        Patient patient = obj as Patient;
                        ((IDoctor)CurrentDoc).DiscardPatient(patient);
                    }));
            }
        }


        private Command saveDoc;
        public Command SaveDoc
        {
            get
            {
                return saveDoc ??
                    (saveDoc = new Command(obj =>
                    {
                        ((IDatabaseCommutable)CurrentDoc).SaveToDb();
                    }));
            }
        }

        private Command saveCurrentPat;
        public Command SaveCurrentPat
        {
            get
            {
                return saveCurrentPat ??
                    (saveCurrentPat = new Command(obj =>
                    {
                        Patient patient = obj as Patient;
                        ((IDatabaseCommutable)patient).SaveToDb();
                    }));
            }
        }

        public Nurse CurrentDoc { get; set; }

        public String DocNameAndRank
        {
            get
            {
                if (CurrentDoc is HeadPhysician)
                    return "Head Physician " + CurrentDoc.Name;
                else if (CurrentDoc is Doctor)
                    return "Doctor " + CurrentDoc.Name;
                else
                    return "Nurse " + CurrentDoc.Name;
            }
        }

        public MeViewModel(Nurse sessionDoctor)
        {
            // LOAD AGAIN TO UPDATE IF SMTH CHANGED; (WE GONNA CALL SOME ERRORS BEEEACH)
            try
            {
                ((IDatabaseCommutable)sessionDoctor).LoadFromDb(sessionDoctor.Id);
            }
            catch (KeyNotFoundException)
            {
                ErrorWindow errorWindow = new ErrorWindow("A database error occured");
                errorWindow.ShowDialog();
            }
            catch (HaveBeenFiredException e)
            {
                ErrorWindow errorWindow = new ErrorWindow(e);
                errorWindow.ShowDialog();
            }

            CurrentDoc = sessionDoctor;
        }
    }



    class PatientViewModel
    {
        public Nurse CurrentDoc { get; set; }

        public ObservableCollection<Patient> AllPatients { get; set; }

        private Command takeSelectedPatient;
        public Command TakeSelectedPatient
        {
            get
            {
                return takeSelectedPatient ??
                    (takeSelectedPatient = new Command(obj =>
                    {
                        Patient patient = obj as Patient;
                        ((IDoctor)CurrentDoc).TakePatient(patient);
                        AllPatients.Remove(patient);
                    }));
            }
        }


        public PatientViewModel(Nurse sessionDoctor)
        {
            try
            {
                ((IDatabaseCommutable)sessionDoctor).LoadFromDb(sessionDoctor.Id);
            }
            catch (KeyNotFoundException)
            {
                ErrorWindow errorWindow = new ErrorWindow("A database error occured");
                errorWindow.ShowDialog();
            }
            catch (HaveBeenFiredException e)
            {
                ErrorWindow errorWindow = new ErrorWindow(e);
                errorWindow.ShowDialog();
            }

            CurrentDoc = sessionDoctor;

            AllPatients = PatientLoader.LoadAll();

            foreach (Patient patient in CurrentDoc.Patients)
            {
                foreach (Patient patientFromAll in AllPatients)
                {
                    if (patientFromAll.Id == patient.Id)
                    {
                        AllPatients.Remove(patientFromAll);
                        break;
                    }
                }
            }
        }
    }



    class NewPatViewModel
    {
        public Nurse CurrentDoc { get; set; }

        public string Name { get; set; }
        public int Room_num { get; set; }
        public string Diseases { get; set; }
        public DateTime Birthdate { get; set; }
        public string Info { get; set; }


        private Command addNewPat;
        public event Action addNewPatCompleted;
        public Command AddNewPat
        {
            get
            {
                return addNewPat ??
                    (addNewPat = new Command(obj =>
                    {
                        Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            { "name", Name },
                            { "room", Room_num },
                            { "diseases", Diseases },
                            { "birthdate", Birthdate },
                            { "info", Info }
                        };

                        CurrentDoc.CreateNewHuman(parameters);

                        addNewPatCompleted?.Invoke();
                    },
                    (obj) => {
                        if (Name == null || Room_num <= 0 || Diseases == null || Birthdate == null)
                        {
                            return false;
                        }
                        return true;
                    }));
            }
        }


        public NewPatViewModel(Nurse sessionDoctor)
        {
            try
            {
                ((IDatabaseCommutable)sessionDoctor).LoadFromDb(sessionDoctor.Id);
            }
            catch (KeyNotFoundException)
            {
                ErrorWindow errorWindow = new ErrorWindow("A database error occured");
                errorWindow.ShowDialog();
            }
            catch (HaveBeenFiredException e)
            {
                ErrorWindow errorWindow = new ErrorWindow(e);
                errorWindow.ShowDialog();
            }

            CurrentDoc = sessionDoctor;
        }
    }



    class DoctorsViewModel
    {
        public Nurse CurrentDoc { get; set; }

        public ObservableCollection<Doctor> AllDoctors { get; set; }
        public ObservableCollection<Nurse> AllNurses { get; set; }
        public ObservableCollection<HeadPhysician> AllHeadPhyses { get; set; }


        private Command discardDoc;
        public Command DiscardDoc
        {
            get
            {
                return discardDoc ??
                    (discardDoc = new Command(obj =>
                    {
                        (CurrentDoc as HeadPhysician).DismissDoctor(obj as Nurse);
                        if (obj is Doctor)
                        {
                            foreach (Doctor doctor in AllDoctors)
                            {
                                if (doctor.Id == (obj as Doctor).Id)
                                {
                                    AllDoctors.Remove(doctor);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            foreach (Nurse nurse in AllNurses)
                            {
                                if (nurse.Id == (obj as Nurse).Id)
                                {
                                    AllNurses.Remove(nurse);
                                    break;
                                }
                            }
                        }
                    },
                    (obj) => CurrentDoc is HeadPhysician));
            }
        }


        public DoctorsViewModel(Nurse sessionDoctor)
        {
            try
            {
                ((IDatabaseCommutable)sessionDoctor).LoadFromDb(sessionDoctor.Id);
            }
            catch (KeyNotFoundException)
            {
                ErrorWindow errorWindow = new ErrorWindow("A database error occured");
                errorWindow.ShowDialog();
            }
            catch (HaveBeenFiredException e)
            {
                ErrorWindow errorWindow = new ErrorWindow(e);
                errorWindow.ShowDialog();
            }

            CurrentDoc = sessionDoctor;

            AllDoctors = PatientLoader.LoadDoctors();
            AllNurses = PatientLoader.LoadNurses();
            AllHeadPhyses = PatientLoader.LoadHeadPhyses();
        }
    }




    class NewDocViewModel
    {
        public HeadPhysician CurrentDoc { get; set; }

        public string Name { get; set; }
        public int Cabinet { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }


        private Command addNewDoc;
        public event Action addDocCompleted;
        public Command AddNewDoc
        {
            get
            {
                return addNewDoc ??
                    (addNewDoc = new Command(obj =>
                    {
                        Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            { "name", Name },
                            { "cabinet", Cabinet },
                            { "birthdate", Birthdate },
                            { "password", Password }
                        };

                        if (Convert.ToString(obj) == "1")
                            CurrentDoc.CreateNewHuman(parameters, Humans.Doctor);
                        else
                            CurrentDoc.CreateNewHuman(parameters, Humans.Nurse);

                        addDocCompleted?.Invoke();
                    },
                    (obj) => {
                        if (Name == null || Cabinet <= 0 || Password == null || Birthdate == null)
                        {
                            return false;
                        }
                        return true;
                    }));
            }
        }


        public NewDocViewModel(HeadPhysician sessionDoctor)
        {
            try
            {
                ((IDatabaseCommutable)sessionDoctor).LoadFromDb(sessionDoctor.Id);
            }
            catch (KeyNotFoundException)
            {
                ErrorWindow errorWindow = new ErrorWindow("A database error occured");
                errorWindow.ShowDialog();
            }
            catch (HaveBeenFiredException e)
            {
                ErrorWindow errorWindow = new ErrorWindow(e);
                errorWindow.ShowDialog();
            }

            CurrentDoc = sessionDoctor;
        }
    }
}
