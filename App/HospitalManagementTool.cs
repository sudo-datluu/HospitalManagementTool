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
                User user = AppScreen.Login();
                AppScreen.HandleUser(user);
            }
        }
    }
}