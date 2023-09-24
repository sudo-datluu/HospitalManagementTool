using HospitalManagementTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Data
{
    // A class to manage data files and app data
    public static class DataManager
    {
        public static readonly string _patientDatabaseFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"Data\Database\patients.txt");
        public static readonly string _doctorDatabaseFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"Data\Database\doctors.txt");
        public static readonly string _assignDatabaseFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"Data\Database\assign.txt");
        public static readonly string _appointmentDatabaseFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"Data\Database\appointments.txt");

        internal static Dictionary<string, Doctor> doctors = new Dictionary<string, Doctor>();
        internal static Dictionary<string, Admin> admins = new Dictionary<string, Admin>();
        internal static Dictionary<string, Patient> patients = new Dictionary<string, Patient>();
        internal static Dictionary<string, User> users = new Dictionary<string, User>();

        //Check files if not exist
        internal static void checkExist(string path)
        {
            try
            {
                StreamWriter sw = File.AppendText(path);
                sw.Close();
            }
            catch (System.IO.DirectoryNotFoundException) {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                StreamWriter sw = File.AppendText(path);
                sw.Close();
            }
        }
        
        // Initialize data from text file
        internal static void initData()
        {
            checkExist(_patientDatabaseFile);
            checkExist(_doctorDatabaseFile);
            checkExist(_assignDatabaseFile);
            checkExist(_appointmentDatabaseFile);

            //Init new admin
            Admin admin = new Admin("admin", "123");
            admins.Add("admin", admin);
            users.Add("admin", admin);

            //init doctor data
            foreach (string line in File.ReadLines(_doctorDatabaseFile))
            {
                string[] parts = line.Split('_');
                Doctor doctor = new Doctor(parts[0], parts[1], parts[2], parts[3],
                        parts[4], parts[5]);
                doctors.Add(parts[0], doctor);
                users.Add(parts[0], doctor);
            }

            //init patients data
            foreach (string line in File.ReadLines(_patientDatabaseFile))
            {
                string[] parts = line.Split('_');
                Patient patient = new Patient(parts[0], parts[1], parts[2], parts[3],
                        parts[4], parts[5]);
                patients.Add(parts[0], patient);
                users.Add(parts[0], patient);
            }

            //init assign doctor to patient data
            foreach (string line in File.ReadLines(_assignDatabaseFile))
            {
                string[] parts = line.Split('_');
                if (doctors.TryGetValue(parts[1], out Doctor? doctor) && 
                    patients.TryGetValue(parts[0], out Patient? patient)) {
                    doctor.Patients.Add(patient.ID, patient);
                    patient.Doctor = doctor;
                }
            }

            //init appointments data
            foreach (string line in File.ReadLines(_appointmentDatabaseFile))
            {
                string[] parts = line.Split('_');
                if (doctors.TryGetValue(parts[0], out Doctor? doctor) &&
                    patients.TryGetValue(parts[1], out Patient? patient))
                {
                    Appointment appointment = new Appointment(doctor, patient, parts[2]);
                    patient.Appointments.Add(appointment);
                }
            }
        }
    }
}
