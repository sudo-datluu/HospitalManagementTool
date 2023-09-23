using HospitalManagementTool.Data;
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
        public string ID { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; } = "";
        public string Address { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public AppRole Role { get; set; }


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

        public User(string id, string password)
        {
            ID = id;
            Password = password;
        }

        // Login method for every user
        // Return false if invalid credential
        static public User? login(string ID, string password)
        {
            User? user;
            if (DataManager.users.TryGetValue(ID, out user))
            {
                if (user.Password == password) return user;
                return null;
            }
            return null;
        }

        // Generate UserID
        // For a new user to add to database
        // It make sure that new generated ID will not be in the existing IDs
        internal static string generateNewUserID()
        {
            string randomString = string.Empty;
            while (randomString == string.Empty || DataManager.users.ContainsKey(randomString))
            {
                randomString = Utility.generateDigits(3, 6);
            }
            return randomString;
        }


        // Write a user to a file
        protected void writeData(string path)
        {
            using (StreamWriter stream = new StreamWriter(path, true))
            {
                stream.WriteLine($"{this.ID}_{this.Password}_{this.Fullname}_{this.Address}_{this.Email}_{this.Phone}");
            }
        }        
    }
}
