using HospitalManagementTool.Domain.Entities;
using HospitalManagementTool.Tools;

namespace HospitalManagementTool.App
{
    class HospitalManagementTool
    {
        static void Main(string[] args)
        {
            User.initData();
            while (true) // For loop to handle user
            {
                User user = AppScreen.Login();
                AppScreen.handle(user); // Handle user till log out
            }
        }
    }
}