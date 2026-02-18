using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalPatientMS2
{
    public class MedicalRecord<T> where T : IPatient
    {
        private T _patient;
        private List<string> _diagnoses = new();
        private Dictionary<DateTime, string> _treatments = new();

        public MedicalRecord(T patient)
        {
            _patient = patient;
        }

        public void AddDiagnosis(string diagnosis, DateTime date)
        {
            _diagnoses.Add($"{date.ToShortDateString()} - {diagnosis}");
        }

        public void AddTreatment(string treatment, DateTime date)
        {
            _treatments[date] = treatment;
        }

        public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
        {
            return _treatments.OrderBy(t => t.Key);
        }
    }

}
