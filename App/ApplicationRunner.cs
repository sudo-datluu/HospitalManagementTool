using HospitalManagementTool.Data;
using HospitalManagementTool.Domain.Entities;
using HospitalManagementTool.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.App
{
    public class ApplicationRunner
    {
        private static User? LoginUser; //Current login runner of the application
        public ApplicationRunner() {
        }

        // Login with credentials given by user input
        private static void login()
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
            LoginUser = User.login(userID, password);
            if (LoginUser==null)
            {
                Utility.PrintMessage("Invalid Credentials", false);
            }
            else
            {
                Utility.PrintMessage("Valid Credentials");
            }
        }

        // Method handle current login user
        private static void handle()
        {
            if (LoginUser != null)
            {
                switch (LoginUser.Role)
                {
                    case AppRole.Doctor:
                        Doctor doctor = DataManager.doctors[LoginUser.ID];
                        doctor.handleMenu();
                        break;
                    case AppRole.Patient:
                        Patient patient = DataManager.patients[LoginUser.ID];
                        patient.handleMenu();
                        break;
                    case AppRole.Admin:
                        Admin admin = DataManager.admins[LoginUser.ID];
                        admin.handleMenu();
                        break;
                }
            }
        }

        public void run() {
            DataManager.initData();
            while (true) //loop to login again
            {
                login(); //login user each time they log out or first time run
                handle(); 
            }
        }
    }
}
