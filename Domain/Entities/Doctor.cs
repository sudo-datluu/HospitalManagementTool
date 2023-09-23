using HospitalManagementTool.Domain.Menu;
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
        public Dictionary<string, Patient> Patients = new Dictionary<string, Patient>();
        public Doctor(string ID, string password, string fullname, string address, string email, string phone) 
            : base(ID, password, fullname, address, email, phone, AppRole.Doctor)
        {
            
        }

        // Handle menu for doctor
        public void handleMenu()
        {
            DoctorMenu menu = new DoctorMenu(this);
            bool isLogIn = true;
            while (isLogIn)
            {
                menu.drawOptions();
                int menuOption = Validator.Convert<Int16>("Your option: ", false, false);
                switch (menuOption)
                {
                    case 1:
                        menu.printDetail();
                        break;
                    case 2:
                        menu.printPatientsDetail();
                        break;
                    case 4:
                        menu.checkPatientDetail();
                        break;
                    case 6:
                        isLogIn = false;
                        break;
                    case 7:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Utility.PrintMessage("Invalid Options. Try Again", false);
                        break;
                }
            }
        }

        // Print a table list of doctors
        internal static void printList(List<Doctor> doctorList)
        {
            var table = new TablePrinter("Name", "Email Address", "Phone", "Address");
            foreach (var doctor in doctorList)
            {
                table.AddRow(doctor.Fullname, doctor.Email, doctor.Phone, doctor.Address);
            }
            table.Print();
        }

        // Save this doctor to database
        public void save()
        {
            if (!User.users.ContainsKey(this.ID)) {
                this.writeData(User.getDoctorFilePath());
                User.doctors.Add(this.ID, this);
                User.users.Add(this.ID, this);
            }
        }
    }
}
