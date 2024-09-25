using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Menu
    {
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
                    PrintPeopleInHospital();
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
                PrintOptions();

                string rawInput = Console.ReadLine();

                if (int.TryParse(rawInput, out int optionIndex))
                {
                    return optionIndex;
                }
            }
        }

        private void PrintOptions()
        {
            Console.WriteLine(
                @"(0) Exit.

(1) Add new Doctor.
(2) Add new Administrative.
(3) Add new Patient.
(4) Remove a Patient.
(5) See Doctors and Patients.
(6) People in the Hospital.");
        }

        private void AddNewDoctor()
        {
            Console.WriteLine("Introduce the data of the new Doctor (Name,Age,ID)");

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
            Console.WriteLine("Introduce the data of the new Administrative (Name,Age,ID)");

            string[] inputData = Console.ReadLine().Split(',');

            Administrative newAdmin;

            if (inputData.Length >= 3 && int.TryParse(inputData[1], out int doctorAge))
            {
                newAdmin = new Administrative(inputData[0], doctorAge, inputData[2]);
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
            Console.WriteLine("Introduce the data of the new Patient (Name,Age,ID,Illness)");

            string[] inputData = Console.ReadLine().Split(',');

            Patient newPatient;

            if (inputData.Length >= 4 && int.TryParse(inputData[1], out int doctorAge))
            {
                newPatient = new Patient(inputData[0], doctorAge, inputData[2], inputData[3]);

                Console.WriteLine("Introduce the doctor's ID assigned to this patient\n");

                PrintDoctorInfo();

                string docId = Console.ReadLine();

                hospital.AddPatient(newPatient, docId);
                Console.WriteLine($"Added Patient: {inputData[0]}");
            }
            else
            {
                Console.WriteLine("Data wasn't introduced correctly.");
            }
        }

        private void RemovePatient()
        {
            Console.WriteLine("Introduce the ID of the patient you want to remove:");
            PrintPatients();
            string patientId = Console.ReadLine();

            var doctors = hospital.GetDoctors();

            try
            {
                var doc = doctors.Find(d => d.HasPatient(patientId));

                doc.RemovePatient(patientId);
            }
            catch 
            { 
                Console.WriteLine("The patient is not assigned to any doctor."); 
            }
        }

        private void PrintDoctorInfo()
        {
            var doctors = hospital.GetDoctors();

            foreach (var doctor in doctors)
                Console.WriteLine(doctor.ToString());
        }

        private void PrintPeopleInHospital()
        {
            Console.WriteLine(hospital.ToString());
        }

        private void PrintPatients()
        {
            var doctors = hospital.GetDoctors();

            foreach(Doctor d in doctors)
            {
                foreach(Patient p in d.GetPatients())
                    Console.WriteLine(p.ToString());
            }
        }
    }
}
