using HospitalManagementTool.Domain.Entities;
using HospitalManagementTool.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Domain.Menu
{
    public class AdminMenu
    {
        Admin Admin;

        public AdminMenu(Admin admin)
        {
            Admin = admin;
        }


        // Draw admin menu
        public void drawOptions()
        {
            string banner =
@"+-------------------+
|DL Hospital Manager|
|-------------------|
|    Admin menu     |
+-------------------+
";
            Utility.writeBanner(banner);
            Console.WriteLine($"Welcome to the DL Hospital Manager Tool {Admin.Role} {Admin.Fullname}");
            Console.WriteLine();
            string options = @"Please choose an option:
1. List all doctors
2. Check doctor details
3. List all patients
4. Check patient detail
5. Add doctor
6. Add patient
7. Logout
8. Exit
";
            Console.WriteLine(options);
        }

        //Add new doctor menu
        public void addDoctor()
        {
            string banner =
@"+--------------------+
|DL Hospital Manager |
|--------------------|
|   Add new doctor   |
+--------------------+
";
            Utility.writeBanner(banner);
            Console.WriteLine("Registering a new doctor in a system");
            string firstname = Validator.Convert<string>("First Name: ", false, false);
            string lastname = Validator.Convert<string>("Last Name: ", false, false);
            string fullname = firstname + " " + lastname;

            string email = Validator.Convert<string>("Email address: ", false, false);
            string phone = Validator.Convert<string>("Phone number: ", false, false);

            string streetNumber = Validator.Convert<string>("Street Number: ", false, false);
            string street = Validator.Convert<string>("Street: ", false, false);
            string city = Validator.Convert<string>("City: ", false, false);
            string state = Validator.Convert<string>("State: ", false, false);
            string address = $"{streetNumber} {street}, {city}, {state}";


            string newID = User.generateNewUserID();
            Doctor doctor = new Doctor(newID, newID, fullname, address, email, phone);
            doctor.save();
            Console.WriteLine($"Doctor: {fullname} has been added to the system");
            Utility.PressKeyContinue();
        }

        //Add new patient menu
        public void addPatient()
        {
            string banner =
@"+---------------------+
|DL Hospital Manager  |
|---------------------|
|   Add new patient   |
+---------------------+
";
            Utility.writeBanner(banner);
            Console.WriteLine("Registering a new patient in a system");
            string firstname = Validator.Convert<string>("First Name: ", false, false);
            string lastname = Validator.Convert<string>("Last Name: ", false, false);
            string fullname = firstname + " " + lastname;

            string email = Validator.Convert<string>("Email address: ", false, false);
            string phone = Validator.Convert<string>("Phone number: ", false, false);

            string streetNumber = Validator.Convert<string>("Street Number: ", false, false);
            string street = Validator.Convert<string>("Street: ", false, false);
            string city = Validator.Convert<string>("City: ", false, false);
            string state = Validator.Convert<string>("State: ", false, false);
            string address = $"{streetNumber} {street}, {city}, {state}";


            string newID = User.generateNewUserID();
            Patient patient = new Patient(newID, newID, fullname, address, email, phone);
            patient.save();
            Console.WriteLine($"Patient: {fullname} has been added to the system");
            Utility.PressKeyContinue();
        }

        //Print all Patients in the database
        public void printAllPatients()
        {
            string banner =
@"+--------------------+
|DL Hospital Manager |
|--------------------|
|  Patients detail   |
+--------------------+
";
            Utility.writeBanner(banner);
            Patient.printList(User.patients.Values.ToList());
            Console.WriteLine();
            Utility.PressKeyContinue();
        }

        //Print All Doctors in the database
        public void printAllDoctors()
        {
            string banner =
@"+--------------------+
|DL Hospital Manager |
|--------------------|
|   Doctors detail   |
+--------------------+
";
            Utility.writeBanner(banner);
            Doctor.printList(User.doctors.Values.ToList());
            Console.WriteLine();
            Utility.PressKeyContinue();
        }

        // Search for a patient
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
                if (User.patients.TryGetValue(patientID, out Patient? patient))
                {
                    Console.WriteLine($"Detail for patient {patientID}");
                    Patient.printList(new List<Patient> { patient });
                }
                else
                {
                    Console.WriteLine($"There is no patient match with ID: {patientID}");
                }
                Console.WriteLine("Press Esc to exit, press any key to continue");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) break;
            }
        }

        // Search for a doctor
        public void checkDoctorDetail()
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
                string doctorID = Validator.Convert<string>("Enter doctor ID: ");
                if (User.doctors.TryGetValue(doctorID, out Doctor? doctor))
                {
                    Console.WriteLine($"Detail for patient {doctorID}");
                    Doctor.printList(new List<Doctor> { doctor });
                }
                else
                {
                    Console.WriteLine($"There is no patient match with ID: {doctorID}");
                }
                Console.WriteLine("Press Esc to exit, press any key to continue");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) break;
            }
        }
    }
}
