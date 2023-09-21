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
            string banner = 
@"+-------------------+
|DL Hospital Manager|
|-------------------|
|      Login        |
+-------------------+
";
            Utility.writeBanner(banner);
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
        internal static void handle(User user) {
            if (user != null)
            {
                switch (user.Role)
                {
                    case AppRole.Doctor:
                        Doctor doctor = User.doctors[user.ID];
                        break;
                    case AppRole.Patient:
                        Patient patient = User.patients[user.ID];
                        patient.handleMenu();
                        break;
                    case AppRole.Admin:
                        Admin admin = User.admins[user.ID];
                        admin.handleMenu();
                        break;
                }
            }
            
        }

    }
}
