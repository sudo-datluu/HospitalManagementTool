using HospitalManagementTool.Data;
using HospitalManagementTool.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Domain.Entities
{
    // Class for appointment
    public class Appointment
    {
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

        public string Descrition { get; set; } = "";

        public Appointment(Doctor doctor, Patient patient, string descrition)
        {
            Doctor = doctor;
            Patient = patient;
            Descrition = descrition;
        }

        // Print list of appointment
        public static void printList(List<Appointment> appointments)
        {
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments available.");
                return;
            }
            var table = new TablePrinter("Doctor", "Patient", "Description");
            appointments.ForEach(appointment =>
                table.AddRow(appointment.Doctor.Fullname, appointment.Patient.Fullname, appointment.Descrition));
            table.Print();
        }

        // Save appointment to database
        public void save()
        {
            using (StreamWriter stream = new StreamWriter(DataManager._appointmentDatabaseFile, true))
            {
                stream.WriteLine($"{this.Doctor.ID}_{this.Patient.ID}_{this.Descrition}");
            }
            this.Patient.Appointments.Add(this);
        }
    }
}
