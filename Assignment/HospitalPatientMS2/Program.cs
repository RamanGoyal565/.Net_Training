using HospitalPatientMS2;
using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        // a) Create patients
        var child1 = new PediatricPatient
        {
            PatientId = 1,
            Name = "Tommy",
            DateOfBirth = new DateTime(2018, 5, 1),
            BloodType = BloodType.O,
            GuardianName = "Mrs. Smith",
            Weight = 18
        };

        var child2 = new PediatricPatient
        {
            PatientId = 2,
            Name = "Emma",
            DateOfBirth = new DateTime(2016, 3, 10),
            BloodType = BloodType.A,
            GuardianName = "Mr. Brown",
            Weight = 12
        };

        var elderly1 = new GeriatricPatient
        {
            PatientId = 3,
            Name = "John",
            DateOfBirth = new DateTime(1945, 8, 20),
            BloodType = BloodType.B,
            MobilityScore = 4
        };
        elderly1.ChronicConditions.Add("Diabetes");

        var elderly2 = new GeriatricPatient
        {
            PatientId = 4,
            Name = "Mary",
            DateOfBirth = new DateTime(1940, 1, 15),
            BloodType = BloodType.AB,
            MobilityScore = 7
        };

        // b) Priority Queue
        var pediatricQueue = new PriorityQueue<PediatricPatient>();
        pediatricQueue.Enqueue(child1, 2);
        pediatricQueue.Enqueue(c
