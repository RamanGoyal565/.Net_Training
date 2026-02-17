using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalPatientMS
{
    public class HospitalManager
    {
        private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
        private Queue<Patient> _appointmentQueue = new Queue<Patient>();

        // Add a new patient to the system
        public void RegisterPatient(int id, string name, int age, string condition)
        {
            // TODO: Create patient and add to dictionary
            if (_patients.ContainsKey(id))
                throw new Exception("Patient Already Exists");
            _patients.Add(id,new Patient(id,name, age, condition));
        }

        // Add patient to appointment queue
        public void ScheduleAppointment(int patientId)
        {
            // TODO: Find patient and add to queue
            if (!_patients.ContainsKey(patientId))
                throw new Exception("Patient not found");
            _appointmentQueue.Enqueue(_patients[patientId]);
        }

        // Process next appointment (remove from queue)
        public Patient ProcessNextAppointment()
        {
            // TODO: Return and remove next patient from queue
            return _appointmentQueue.Dequeue();
        }

        // Find patients with specific condition using LINQ
        public List<Patient> FindPatientsByCondition(string condition)
        {
            // TODO: Use LINQ to filter patients
            return _patients.Values.Where(p=>p.Condition== condition).ToList();
        }
    }
}
