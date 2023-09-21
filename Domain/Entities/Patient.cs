using HospitalManagementTool.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Domain.Entities
{
    public class Patient : User
    {
        public Doctor Doctor { get; set; }

        public Patient(string ID, string password, string fullname, string address, string email, string phone)
            : base(ID, password, fullname, address, email, phone, AppRole.Patient)
        {
        }

        // Handle menu for patient
        public void handleMenu()
        {
            bool isLogIn = true;
            while (isLogIn)
            {
                this.DrawPatientMenu();
                int menuOption = Validator.Convert<Int16>("Your option: ", false, false);
                switch (menuOption)
                {
                    case 1:
                        this.printDetail();
                        break;
                    case 5:
                        isLogIn = false;
                        break;
                    case 6:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Utility.PrintMessage("Invalid Options. Try Again", false);
                        break;
                }
            }
        }

        
        
        //Printing detail of a patient.
        public void printDetail()
        {
            string banner = 
@"+-------------------+
|DL Hospital Manager|
|-------------------|
| My Patient detail |
+-------------------+
";
            Utility.writeBanner(banner);
            string result = $@"
Patient ID: {this.ID}
Fullname: {this.Fullname}
Address: {this.Address}
Email: {this.Email}
Phone: {this.Phone}
";
            Console.WriteLine(result);
            Utility.PressKeyContinue();
        }

        // Draw patient menu console UI
        public void DrawPatientMenu()
        {
            string banner = @"
+-------------------+
|DL Hospital Manager|
|-------------------|
|   Patient Menu    |
+-------------------+
";
            Utility.writeBanner(banner);
            Console.WriteLine($"Welcome to the DL Hospital Manager Tool {this.Fullname}");
            Console.WriteLine();
            string patientOptions = @"
Please choose an option:
1. List Patient Details
2. List my doctor detail
3. List all apointments
4. Book appointment
5. Exit to login
6. Exit system
";
            Console.WriteLine(patientOptions);
        }

        // Print a table list of patients
        internal static void printList(List<Patient> patientList)
        {
            var table = new TablePrinter("Name", "Doctor", "Email Address", "Phone", "Address");
            foreach (var patient in patientList)
            {
                if (patient.Doctor == null)
                {
                    table.AddRow(patient.Fullname,string.Empty, patient.Email, patient.Phone, patient.Address);
                }
                else
                {
                    table.AddRow(patient.Fullname, patient.Doctor.Fullname, patient.Email, patient.Phone, patient.Address);
                }
            }
            table.Print();
        }
    }
}
