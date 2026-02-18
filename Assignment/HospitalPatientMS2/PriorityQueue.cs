using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalPatientMS2
{
    public interface IPatient
    {
        int PatientId { get; }
        string Name { get; }
        DateTime DateOfBirth { get; }
        BloodType BloodType { get; }
    }
    public enum BloodType { A, B, AB, O }
    public enum Condition { Stable, Critical, Recovering }
    public class PriorityQueue<T> where T : IPatient
    {
        private SortedDictionary<int, Queue<T>> _queues = new();
        public void Enqueue(T patient, int priority)
        {
            if (priority < 1 || priority > 5)
                throw new ArgumentException("Priority must be between 1 and 5.");

            if (!_queues.ContainsKey(priority))
                _queues[priority] = new Queue<T>();

            _queues[priority].Enqueue(patient);
        }
        public T Dequeue()
        {
            foreach (var pair in _queues.OrderBy(p => p.Key))
            {
                if (pair.Value.Count > 0)
                    return pair.Value.Dequeue();
            }
            throw new InvalidOperationException("Queue is empty.");
        }
        public T Peek()
        {
            foreach (var pair in _queues.OrderBy(p => p.Key))
            {
                if (pair.Value.Count > 0)
                    return pair.Value.Peek();
            }
            throw new InvalidOperationException("Queue is empty.");
        }
        public int GetCountByPriority(int priority)
        {
            return _queues.ContainsKey(priority)
                ? _queues[priority].Count
                : 0;
        }
    }
}
