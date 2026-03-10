using Microsoft.EntityFrameworkCore;
using StudentManagementOneToMany.Data;
using StudentManagementOneToMany.Models;
using StudentManagementOneToMany.Repository;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementOneToMany.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;

        public StudentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return context.Students
                .Include(s => s.AssignedRoom)
                .Include(s => s.Payment)
                .ToList();
        }

        public Student GetById(int id)
        {
            return context.Students.Find(id);
        }

        public void Insert(Student student)
        {
            // Check if room exists
            var room = context.HostelRooms
                .FirstOrDefault(r => r.HostelRoomId == student.HostelRoomId);

            // If room not exists → create it
            if (room == null)
            {
                room = new HostelRoom
                {
                    RoomNumber = student.HostelRoomId,
                    Capacity = 4
                };

                context.HostelRooms.Add(room);
                context.SaveChanges();

                student.HostelRoomId = room.HostelRoomId;
            }

            context.Students.Add(student);
        }

        public void Update(Student student)
        {
            context.Students.Update(student);
        }

        public void Delete(int id)
        {
            var student = context.Students.Find(id);
            context.Students.Remove(student);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}