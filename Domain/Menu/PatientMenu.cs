using HospitalManagementTool.Data;
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

        // List all patient appointments
        public void printMyAppointments()
        {
            string banner =
@"+-----------------------------+
|     DL Hospital Manager     |
|-----------------------------|
|       My Appointments       |
+-----------------------------+
";
            Utility.writeBanner(banner);
            Appointment.printList(Patient.Appointments);
            Utility.PressKeyContinue();
        }

        // Book appointment
        public void bookAppointment()
        {
            string banner =
@"+-----------------------------+
|     DL Hospital Manager     |
|-----------------------------|
|      Book Appointment       |
+-----------------------------+
";
            while (true)
            {
                Utility.writeBanner(banner);
                if (Patient.Doctor == null)
                {
                    Console.WriteLine("You are not registered with any doctor. Please choose your doctor");
                    Doctor.printList(DataManager.doctors.Values.ToList());

                    string registerDoctorID = Validator.Convert<string>("Enter wishful doctor ID: ");
                    if (DataManager.doctors.TryGetValue(registerDoctorID, out Doctor? doctor))
                    {
                        Patient.saveDoctor(doctor);
                    }
                    else
                    {
                        Utility.PrintMessage("Invalid input. Please try again", false);
                        continue;
                    }
                }
                Console.WriteLine($"You are booking a new appointment with {Patient.Doctor.Fullname}");
                string description = Validator.Convert<string>("Enter Appointment Description: ");
                Appointment appointment = new Appointment(Patient.Doctor, Patient, description);
                appointment.save();
                Console.WriteLine();
                Console.WriteLine("Booking success! Press Esc to exit, press any key to continue booking");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) break;
            }
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
