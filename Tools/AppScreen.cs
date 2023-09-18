using HospitalManagementTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Tools
{
    public static class AppScreen
    {
        // Method for print login screen
        internal static User Login()
        {
            string banner = @"
+-------------------+
|DL Hospital Manager|
|-------------------|
|      Login        |
+-------------------+
";
            Console.Clear();
            Console.WriteLine(banner);
            Console.WriteLine();
            string userID = Validator.Convert<string>("ID: ");
            string password = Utility.GetSecretInput("Password: ");
            User user = User.login(userID, password);
            if (user == null)
            {
                Utility.PrintMessage("Invalid Credentials", false);
            }
            else
            {
                Utility.PrintMessage("Valid Credentials");
            }
            return user;
        }

        // Method print different type of user screens
        internal static void HandleUser(User user) {
            if (user != null)
            {
                switch (user.Role)
                {
                    case AppRole.Doctor:
                        Doctor doctor = new Doctor(user.ID, user.Password, user.Fullname, user.Address, user.Email, user.Phone);
                        break;
                    case AppRole.Patient:
                        Patient patient = new Patient(user.ID, user.Password, user.Fullname, user.Address, user.Email, user.Phone);
                        patient.handleMenu();
                        break;
                }
            }
            
        }

    }
}
