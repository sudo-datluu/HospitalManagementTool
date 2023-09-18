using HospitalManagementTool.Domain.Entities;
using HospitalManagementTool.Tools;

namespace HospitalManagementTool.App
{
    class HospitalManagementTool
    {
        static void Main(string[] args)
        {
            // For loop to handle user
            while (true)
            {
                User user = AppScreen.Login();
                AppScreen.HandleUser(user); // Handle user till log out
            }
        }
    }
}