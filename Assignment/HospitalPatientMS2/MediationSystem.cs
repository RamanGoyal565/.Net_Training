using System;
using System.Collections.Generic;
using System.Text;
namespace HospitalPatientMS2
{
    public class PediatricPatient : IPatient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }
        public string GuardianName { get; set; }
        public double Weight { get; set; } // in kg
    }
    public class GeriatricPatient : IPatient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }
        public List<string> ChronicConditions { get; } = new();
        public int MobilityScore { get; set; } // 1-10
    }

    public class MedicationSystem<T> where T : IPatient
    {
        private Dictionary<T, List<(string medication, DateTime time)>> _medications = new();
        public void PrescribeMedication(T patient, string medication, Func<T, bool> dosageValidator)
        {
            if (!dosageValidator(patient))
                throw new InvalidOperationException("Dosage invalid for patient.");
            if (!_medications.ContainsKey(patient))
                _medications[patient] = new List<(string, DateTime)>();
            if (CheckInteractions(patient, medication))
                throw new InvalidOperationException("Drug interaction detected.");

            _medications[patient].Add((medication, DateTime.Now));
        }
        public bool CheckInteractions(T patient, string newMedication)
        {
            if (!_medications.ContainsKey(patient))
                return false;
            return _medications[patient]
                .Any(m => m.medication == newMedication);
        }
    }
}