using HospitalManagementTool.Domain.Entities;
using HospitalManagementTool.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Domain.Menu
{
    public class PatientMenu
    {
        public Patient Patient { get; set; }
        public PatientMenu(Patient patient) {
            this.Patient = patient;
        }
        //Printing detail of a patient.
        public void printDetail()
        {
            string banner =
@"+-------------------+
|DL Hospital Manager|
|-------------------|
| My Patient detail |
+-------------------+
";
            Utility.writeBanner(banner);
            string result = $@"
Patient ID: {Patient.ID}
Fullname: {Patient.Fullname}
Address: {Patient.Address}
Email: {Patient.Email}
Phone: {Patient.Phone}
";
            Console.WriteLine(result);
            Utility.PressKeyContinue();
        }

        //List doctor detail of a patient
        public void printMyDoctorDetail()
        {
            string banner = 
@"+-----------------------------+
|     DL Hospital Manager     |
|-----------------------------|
|       My doctor detail      |
+-----------------------------+
";
            Utility.writeBanner(banner);
            if (Patient.Doctor != null)
            {
                Doctor.printList(new List<Doctor> { Patient.Doctor });
            }
            else Console.WriteLine("You have not registered to any doctor");
            Utility.PressKeyContinue();
        }

        // Draw patient menu console UI
        public void drawOptions()
        {
            string banner = @"
+-------------------+
|DL Hospital Manager|
|-------------------|
|   Patient Menu    |
+-------------------+
";
            Utility.writeBanner(banner);
            Console.WriteLine($"Welcome to the DL Hospital Manager Tool {Patient.Fullname}");
            Console.WriteLine();
            string patientOptions = @"
Please choose an option:
1. List Patient Details
2. List my doctor detail
3. List all apointments
4. Book appointment
5. Exit to login
6. Exit system
";
            Console.WriteLine(patientOptions);
        }
    }
}
