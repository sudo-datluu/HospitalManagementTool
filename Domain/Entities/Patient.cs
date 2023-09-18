using HospitalManagementTool.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Domain.Entities
{
    public class Patient : User
    {
        public Patient(string ID, string password, string fullname, string address, string email, string phone) : base(ID, password, fullname, address, email, phone, AppRole.Doctor)
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

        /*
         Method for printing detail of a patient
         */
        public void printDetail()
        {
            string banner = @"
+-------------------+
|DL Hospital Manager|
|-------------------|
| My Patient detail |
+-------------------+
";
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(banner);
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

        /*
         Method for printing Menu option for patient user
         */
        public void DrawPatientMenu()
        {
            string banner = @"
+-------------------+
|DL Hospital Manager|
|-------------------|
|   Patient Menu    |
+-------------------+
";
            Console.Clear();
            Console.WriteLine(banner);
            Console.WriteLine();
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
    }

}
