using HospitalManagementTool.Domain.Entities;
using HospitalManagementTool.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Domain.Menu
{
    public class DoctorMenu
    {
        Doctor Doctor;

        public DoctorMenu(Doctor doctor)
        {
            Doctor = doctor;
        }


        // Draw doctor menu
        public void drawOptions()
        {
            string banner =
@"+---------------------+
| DL Hospital Manager |
|---------------------|
|     Doctor menu     |
+---------------------+
";
            Utility.writeBanner(banner);
            Console.WriteLine($"Welcome to the DL Hospital Manager Tool Doctor {Doctor.Fullname}");
            Console.WriteLine();
            string options = @"Please choose an option:
1. List doctor details
2. List patients
3. List appointments
4. Check particular patient
5. List appointments with patient
6. Logout
7. Exit
";
            Console.WriteLine(options);
        }

        //Printing detail of a doctor.
        public void printDetail()
        {
            string banner =
@"+-------------------+
|DL Hospital Manager|
|-------------------|
|   Doctor detail   |
+-------------------+
";
            Utility.writeBanner(banner);
            Doctor.printList(new List<Doctor> { Doctor });
            Utility.PressKeyContinue();
        }

        //Print all patients assigned to doctor detail
        public void printPatientsDetail()
        {
            string banner =
@"+---------------------+
| DL Hospital Manager |
|---------------------|
|   Patients detail   |
+---------------------+
";
            Utility.writeBanner(banner);
            Console.WriteLine($"Patients assigned to {Doctor.Fullname}:");
            if (Doctor.Patients.Count == 0) Console.WriteLine("You have not assigned to any patient");
            else Patient.printList(Doctor.Patients.Values.ToList(), false);
            Utility.PressKeyContinue();
        }

        // Search for a patient of this doctor
        public void checkPatientDetail()
        {

            while (true)
            {
                string banner =
@"+----------------------------+
|    DL Hospital Manager     |
|----------------------------|
|    Check patient detail    |
+----------------------------+
";
                Utility.writeBanner(banner);
                string patientID = Validator.Convert<string>("Enter patient ID: ");
                if (Doctor.Patients.TryGetValue(patientID, out Patient? patient))
                {
                    Console.WriteLine($"Detail for patient {patientID}");
                    Patient.printList(new List<Patient> { patient }, false);
                }
                else
                {
                    Console.WriteLine($"There is no patient assigned to {Doctor.Fullname} that match with ID: {patientID}");
                }
                Console.WriteLine("Press Esc to exit, press any key to continue");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) break;
            }
        }
    }
}
