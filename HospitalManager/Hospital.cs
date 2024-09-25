﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Hospital
    {
        List<Person> people;

        public Hospital() 
        {
            people = new List<Person>();
        }

        public void AddDoctor(Doctor doctor)
        {
            people.Add(doctor);
        }

        public void RemoveDoctor(Doctor doctor) 
        { 
            people.Remove(doctor);
        }

        public void AddAdministrative(Administrative administrative) 
        { 
            people.Add(administrative);
        }

        public void RemoveAdministrative(Administrative administrative)
        {
            people.Remove(administrative);
        }

        public void AddPatient(Patient patient, string doctorId)
        {
            try
            {
                ((Doctor)people.Find(d => d.Id == doctorId)).AddPatient(patient);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The doctor assigned to that ID couldn't be found: {ex.Message}");
            }
        }

        public void RemovePatient(string patientId, string doctorId)
        {
            try
            {
                ((Doctor) people.Find(d => d.Id == doctorId)).RemovePatient(patientId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The doctor or patient assigned to that ID couldn't be found: {ex.Message}");
            }
        }

        public override string ToString()
        {
            string output = "";
            output += "Doctors: \n";
            foreach (Person p in people)
            {
                if (p is Doctor)
                    output += p.ToString() + "\n";
            }

            output += "Administratives: \n";
            foreach (Person p in people)
            {
                if (p is Administrative)
                    output += p.ToString() + "\n";
            }

            return output;
        }

        public List<Doctor> GetDoctors()
        {
            List<Person> docs = people.Where(p => p is Doctor).ToList();
            List<Doctor> result = new List<Doctor>();

            foreach (var p in docs)
            {
                result.Add(p as Doctor);
            }

            return result;
        }
    }
}
