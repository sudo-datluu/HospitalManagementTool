using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Domain.Entities
{
    public class Doctor : User
    {
        public Doctor(string ID, string password, string fullname, string address, string email, string phone) : base(ID, password, fullname, address, email, phone, AppRole.Doctor)
        {
        }
    }
}
