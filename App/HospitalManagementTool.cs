using HospitalManagementTool.Domain.Entities;
using HospitalManagementTool.Tools;

namespace HospitalManagementTool.App
{
    class HospitalManagementTool
    {
        static void Main(string[] args)
        {
            while (true)
            {
                AppScreen.Login();
                string userID = Validator.Convert<string>("ID: ");
                string password = Validator.Convert<string>("Password: ");
                User user = User.login(userID, password);
                if (user == null)
                {
                    Utility.PrintMessage("Invalid Credentials", false);
                }
                else
                {
                    Utility.PrintMessage("Valid Credentials");
                }
            }
        }
    }
}