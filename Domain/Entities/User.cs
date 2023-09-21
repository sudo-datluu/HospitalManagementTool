using HospitalManagementTool.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public enum AppRole
{
    Patient,
    Doctor,
    Admin
}

namespace HospitalManagementTool.Domain.Entities
{
    /*
     Class represent for user of a system
     Contain common info and method for different type of user
     */
    public class User
    {
        static readonly string _adminDatabaseFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"Database\admins.txt");
        static readonly string _patientDatabaseFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"Database\patients.txt");
        static readonly string _doctorDatabaseFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"Database\doctors.txt");

        public static Dictionary<string, Doctor> doctors =  new Dictionary<string, Doctor>();
        public static Dictionary<string, Admin> admins = new Dictionary<string, Admin>();
        public static Dictionary<string, Patient> patients = new Dictionary<string, Patient>();
        public static Dictionary<string, User> users = new Dictionary<string, User>();

        // Initialize data from text file
        internal static void initData()
        {
            //init admin data
            foreach (string line in File.ReadLines(_adminDatabaseFile))
            {
                string[] parts = line.Split(',');
                Admin admin = new Admin(parts[0], parts[1], parts[2], parts[3],
                        parts[4], parts[5]);
                admins.Add(parts[0], admin);
                users.Add(parts[0], admin);
            }

            //init doctor data
            foreach (string line in File.ReadLines(_doctorDatabaseFile))
            {
                string[] parts = line.Split(',');
                Doctor doctor = new Doctor(parts[0], parts[1], parts[2], parts[3],
                        parts[4], parts[5]);
                doctors.Add(parts[0],doctor);
                users.Add(parts[0], doctor);
            }

            //init patients data
            foreach (string line in File.ReadLines(_patientDatabaseFile))
            {
                string[] parts = line.Split(',');
                Patient patient = new Patient(parts[0], parts[1], parts[2], parts[3],
                        parts[4], parts[5]);
                if (parts.Length > 6)
                {
                    patient.Doctor = doctors[parts[6]];
                    doctors[parts[6]].Patients.Add(patient);
                }
                patients.Add(parts[0], patient);
                users.Add(parts[0], patient);
            }
        }

        public string ID { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public AppRole Role { get; }


        public User(string id, string password, string fullname, string address, string email, string phone, AppRole role)
        {
            ID = id;
            Password = password;
            Fullname = fullname;
            Address = address;
            Email = email;
            Phone = phone;
            Role = role;
        }


        // Login method for every user
        // Return false if invalid credential
        static public User login(string ID, string password)
        {
            User user;
            if (users.TryGetValue(ID, out user))
            {
                if (user.Password == password) return user;
                return null;
            }
            return null;
        }


        internal static string generateNewUserID()
        {
            string randomString = string.Empty;
            while (randomString == string.Empty || User.users.ContainsKey(randomString))
            {
                randomString = Utility.generateDigits(3, 6);
            }
            return randomString;
        }


        // Write a data to a file
        protected void writeData(string path)
        {
            using (StreamWriter stream = new StreamWriter(path, true))
            {
                stream.WriteLine($"{this.ID},{this.Password},{this.Address},{this.Email},{this.Phone}");
            }
        }

        protected static string getDoctorFilePath() => _doctorDatabaseFile;
        protected static string getPatitentFilePath() => _patientDatabaseFile;
    }
}
