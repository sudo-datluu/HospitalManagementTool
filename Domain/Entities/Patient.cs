﻿using HospitalManagementTool.Data;
using HospitalManagementTool.Domain.Menu;
using HospitalManagementTool.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Domain.Entities
{
    public class Patient : User
    {
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public Doctor? Doctor { get; set; }

        public Patient(string ID, string password, string fullname, string address, string email, string phone)
            : base(ID, password, fullname, address, email, phone, AppRole.Patient)
        {
        }

        // Handle menu for patient
        public void handleMenu()
        {
            PatientMenu menu = new PatientMenu(this);
            bool isLogIn = true;
            while (isLogIn)
            {
                menu.drawOptions();
                int menuOption = Validator.Convert<Int16>("Your option: ", false, false);
                switch (menuOption)
                {
                    case 1:
                        menu.printDetail();
                        break;
                    case 2:
                        menu.printMyDoctorDetail();
                        break;
                    case 3:
                        menu.printMyAppointments();
                        break;
                    case 4:
                        menu.bookAppointment();
                        break;
                    case 5:
                        isLogIn = false;
                        break;
                    case 6:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Utility.PrintMessage("Invalid Options. Try Again", false);
                        break;
                }
            }
        }

        // Print a table list of patients
        internal static void printList(List<Patient> patientList, bool withDoctor=true)
        {

            if (withDoctor) 
            {
                var table = new TablePrinter("ID", "Name", "Doctor", "Email Address", "Phone", "Address");
                foreach (var patient in patientList)
                {
                    if (patient.Doctor == null)
                    {
                        table.AddRow(patient.ID, patient.Fullname, string.Empty, patient.Email, patient.Phone, patient.Address);
                    }
                    else
                    {
                        table.AddRow(patient.ID, patient.Fullname, patient.Doctor.Fullname, patient.Email, patient.Phone, patient.Address);
                    }
                }
                table.Print();
            }
            else
            {
                var table = new TablePrinter("ID","Name", "Email Address", "Phone", "Address");
                patientList.ForEach(patient =>
                {
                    table.AddRow(patient.ID, patient.Fullname, patient.Email, patient.Phone, patient.Address);
                });
                table.Print();
            }
            
        }

        // Save my doctor to database
        public void saveDoctor(Doctor doctor)
        {
            if (this.Doctor == null)
            {
                Doctor = doctor;
                doctor.Patients.Add(this.ID, this);
                using (StreamWriter stream = new StreamWriter(DataManager._assignDatabaseFile, true))
                {
                    stream.WriteLine($"{this.ID}_{this.Doctor.ID}");
                }
            }
        }

        // Save this paitent to database
        public void save()
        {
            if (!DataManager.users.ContainsKey(this.ID))
            {
                this.writeData(DataManager._patientDatabaseFile);
                DataManager.patients.Add(this.ID, this);
                DataManager.users.Add(this.ID, this);
            }
        }
    }
}
