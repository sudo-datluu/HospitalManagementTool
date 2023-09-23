using HospitalManagementTool.Domain.Entities;
using HospitalManagementTool.Tools;

namespace HospitalManagementTool.App
{
    class HospitalManagementTool
    {
        static void Main(string[] args)
        {
            ApplicationRunner application = new ApplicationRunner();
            application.run();
        }
    }
}