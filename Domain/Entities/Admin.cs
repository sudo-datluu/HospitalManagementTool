using HospitalManagementTool.Domain.Menu;
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
        public Admin(string id, string password, string fullname, string address, string email, string phone) 
            : base(id, password, fullname, address, email, phone, AppRole.Admin)
        {
        }

        // Handle menu for admin user
        public void handleMenu()
        {
            bool isLogIn = true;
            while (isLogIn)
            {
                AdminMenu menu = new AdminMenu(this);
                menu.drawOptions();
                int menuOption = Validator.Convert<Int16>("Your option: ", false, false); // Get key option
                switch (menuOption)
                {
                    case 1:
                        menu.printAllDoctors();
                        break;
                    case 3:
                        menu.printAllPatients();
                        break;
                    case 5:
                        menu.addDoctor();
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
    }
}
