using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Menu
    {
        private const string MainMenu = @"(0) Exit.

(1) Add new Doctor.
(2) Add new Administrative.
(3) Add new Patient.
(4) Remove a Patient.
(5) See Doctors.
(6) See Patients.
(7) People in the Hospital.

(8) Manage Patients appointments";

        private const string AppointmentMenu = @"(0) Exit.

(1) Add appointment.
(2) Modify appointment.
(3) Remove appointment.";

        Hospital hospital;
        public Menu()
        {
            hospital = new Hospital();
        }

        public void Start()
        {
            while (true)
            {
                if (SelectOption(GetUserIntInput()))
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                else
                    return;
            }
        }

        private bool SelectOption(int option)
        {
            Console.Clear();

            switch (option)
            {
                case 0:
                    return false;

                case 1:
                    AddNewDoctor();
                    break;

                case 2:
                    AddNewAdministrative();
                    break;

                case 3:
                    AddNewPatient();
                    break;

                case 4:
                    RemovePatient();
                    break;

                case 5:
                    PrintDoctorInfo();
                    break;

                case 6:
                    PrintPatients();
                    break;

                case 7:
                    PrintPeopleInHospital();
                    break;

                case 8:
                    ManageAppointments();
                    break;

                default:
                    break;

            }
            return true;
        }

        private int GetUserIntInput()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select an option:");
                PrintOptions(MainMenu);

                string rawInput = Console.ReadLine();

                if (int.TryParse(rawInput, out int optionIndex))
                {
                    return optionIndex;
                }
            }
        }

        private void PrintOptions(string menuOptions)
        {
            Console.WriteLine(menuOptions);
        }

        private void AddNewDoctor()
        {
            Console.WriteLine("Introduce the data of the new Doctor (Name,Age,Specialty)");

            string[] inputData = Console.ReadLine().Split(',');

            Doctor newDoc;

            if (inputData.Length >= 3 && int.TryParse(inputData[1], out int doctorAge))
            {
                newDoc = new Doctor(inputData[0], doctorAge, inputData[2]);
                hospital.AddDoctor(newDoc);
                Console.WriteLine($"Added Doctor: {inputData[0]}");
            }
            else
            {
                Console.WriteLine("Data wasn't introduced correctly.");
            }
        }

        private void AddNewAdministrative()
        {
            Console.WriteLine("Introduce the data of the new Administrative (Name,Age)");

            string[] inputData = Console.ReadLine().Split(',');

            Administrative newAdmin;

            if (inputData.Length >= 3 && int.TryParse(inputData[1], out int doctorAge))
            {
                newAdmin = new Administrative(inputData[0], doctorAge);
                hospital.AddAdministrative(newAdmin);
                Console.WriteLine($"Added Administrative: {inputData[0]}");
            }
            else
            {
                Console.WriteLine("Data wasn't introduced correctly.");
            }
        }

        private void AddNewPatient()
        {
            Console.WriteLine("Introduce the data of the new Patient (Name,Age,Illness)");

            string[] inputData = Console.ReadLine().Split(',');

            Patient newPatient;

            if (inputData.Length >= 4 && int.TryParse(inputData[1], out int age))
            {
                while(true)
                {
                    Console.WriteLine("Introduce the doctor's ID assigned to this patient\n");

                    PrintDoctorInfo();

                    string idInput = Console.ReadLine();
                    if (int.TryParse(idInput, out int docId))
                    {
                        newPatient = new Patient(inputData[0], age, inputData[2], inputData[3]);
                        hospital.AddPatient(newPatient, docId);

                        Console.WriteLine($"Added Patient: {inputData[0]}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Data wasn't introduced correctly.");
            }
        }

        private void RemovePatient()
        {
            hospital.RemovePatient(GetPatientID());
        }

        private void PrintDoctorInfo()
        {
            var doctors = hospital.GetDoctors();

            foreach (var doctor in doctors)
                Console.WriteLine(doctor.ToString());
        }
        private void PrintPatients()
        {
            foreach(Patient p in hospital.GetPatients())
                Console.WriteLine(p.ToString());
        }

        private void PrintPeopleInHospital()
        {
            Console.WriteLine(hospital.ToString());
        }

        private void ManageAppointments()
        {
            Console.Clear();
            PrintOptions(AppointmentMenu);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int optionIndex))
            {
                Console.WriteLine("Select an option: ");
                switch (optionIndex)
                {
                    case 0:
                        return;

                    case 1:
                        AddNewAppointment(GetPatientID());
                        break;

                    case 2:
                        GetPatientID();
                        break;

                    case 3:
                        GetPatientID();
                        break;

                    default:
                        break;
                }
            }
        }

        private int GetPatientID()
        {
            while (true)
            {
                PrintPatients();
                Console.WriteLine("Write the ID of the patient: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                    return id;
                else
                    Console.WriteLine("Unable to identify the ID");
            }
        }

        private void AddNewAppointment(int patientId)
        {
            int year, month, day, hour, minute;
            year = month = day = hour = minute = 0;

            DateTime inputTime;

            while (true)
            {
                Console.WriteLine("Specify the date of the appointment (DD/MM/YYYY): ");
                string inputDate = Console.ReadLine();
                if(DateTime.TryParse(inputDate, out inputTime))
                {
                    Console.WriteLine("Specify the hour of the appointment (hh:mm): ");
                    string[] inputHour = Console.ReadLine().Split(':');

                    if(int.TryParse(inputHour[0], out hour) && int.TryParse(inputHour[1], out minute))
                    {
                        inputTime.AddHours(hour);
                        inputTime.AddMinutes(minute);

                        Console.WriteLine("Add aditional notes: ");
                        string inputNotes = Console.ReadLine();

                        hospital.GetPatientByID(patientId).AddAppointment(new Appointment(inputTime, inputNotes));
                    }
                    else 
                        continue;
                }
            }
        }

    }
}
