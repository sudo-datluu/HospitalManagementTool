using ConsoleTables;
using HospitalManagementTool.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Domain.Entities
{
    public class Doctor : User
    {
        public List<Patient> Patients { get; set; }
        public Doctor(string ID, string password, string fullname, string address, string email, string phone) : base(ID, password, fullname, address, email, phone, AppRole.Doctor)
        {
            Patients = new List<Patient>();
        }

        // Print a table list of doctors
        internal static void printList(List<Doctor> doctorList)
        {
            var table = new ConsoleTable("Name", "Email Address", "Phone", "Address");
            foreach (var doctor in doctorList)
            {
                table.AddRow(doctor.Fullname, doctor.Email, doctor.Phone, doctor.Address);
            }
            table.Write();
        }
    }
}
