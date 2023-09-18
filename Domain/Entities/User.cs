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
    Administrator
}

namespace HospitalManagementTool.Domain.Entities
{
    public class User
    {
        private static readonly string _userDatabaseFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"Database\users.txt");

        public string ID { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public AppRole Role { get; }


        public User(string ID, string password, string fullname, string address, string email, string phone, AppRole role)
        {
            ID = ID;
            Password = password;
            Fullname = fullname;
            Address = address;
            Email = email;
            Phone = phone;
            Role = role;
        }

        static public User login(string ID, string password)
        {
            foreach (string line in File.ReadLines(_userDatabaseFile))
            {
                string[] parts = line.Split(',');
                if (parts[0].Equals(ID) && parts[1].Equals(password))  {
                    return new User(parts[0], parts[1], parts[2], parts[3],
                        parts[4], parts[5], (AppRole)Enum.Parse(typeof(AppRole), parts[6]));
                };
            }
            return null;
        }
    }
}
