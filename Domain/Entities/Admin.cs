using HospitalManagementTool.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Domain.Entities
{
    public class Admin : User
    {
        public Admin(string id, string password, string fullname, string address, string email, string phone) : base(id, password, fullname, address, email, phone, AppRole.Admin)
        {
        }

        // Handle menu for admin user
        public void handleMenu()
        {
            bool isLogIn = true;
            while (isLogIn)
            {
                this.drawMenu();
                int menuOption = Validator.Convert<Int16>("Your option: ", false, false); // Get key option
                switch (menuOption)
                {
                    case 1:
                        this.printAllDoctors();
                        break;
                    case 3:
                        this.printAllPatients();
                        break;
                    case 7:
                        isLogIn = false;
                        break;
                    case 8:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Utility.PrintMessage("Invalid Options. Try Again", false);
                        break;
                }
            }
        }

        // Option 1: Print All Doctors in the database
        public void printAllDoctors()
        {
            string banner = @"
+--------------------+
|DL Hospital Manager |
|--------------------|
|   Doctors detail   |
+--------------------+
";
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(banner);
            Doctor.printList(User.doctors.Values.ToList());
            Console.WriteLine();
            Utility.PressKeyContinue();
        }

        // Option 3: Print all Patients
        public void printAllPatients()
        {
            string banner = @"
+--------------------+
|DL Hospital Manager |
|--------------------|
|  Patients detail   |
+--------------------+
";
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(banner);
            Patient.printList(User.patients.Values.ToList());
            Console.WriteLine();
            Utility.PressKeyContinue();
        }

        // Draw admin menu
        public void drawMenu()
        {
            string banner = @"
+-------------------+
|DL Hospital Manager|
|-------------------|
|    Admin menu     |
+-------------------+
";
            Console.Clear();
            Console.WriteLine(banner);
            Console.WriteLine();
            Console.WriteLine($"Welcome to the DL Hospital Manager Tool {this.Role} {this.Fullname}");
            Console.WriteLine();
            string options = @"
Please choose an option:
1. List all doctors
2. Check doctor details
3. List all patients
4. Check patient detail
5. Add doctor
6. Add patient
7. Logout
8. Exit
";
            Console.WriteLine(options);
        }
    }
}
