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
                if (parts.Length > 6)
                {
                    patient.Doctor = doctors[parts[6]];
                    doctors[parts[6]].Patients.Add(patient.ID, patient);
                }
                patients.Add(parts[0], patient);
                users.Add(parts[0], patient);
            }
        }
    }
}
