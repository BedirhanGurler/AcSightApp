using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class StudentRepository : IStudentReporsitory
    {
        public Student CreateStudent(Student student)
        {
            using (var acSightDbContext = new AcSightDbContext())
            {
                acSightDbContext.Students.Add(student);
                acSightDbContext.SaveChanges();
                return student;
            }
        }

        public void DeleteStudent(int id)
        {
            using (var acSightDbContext = new AcSightDbContext())
            {
                var deleteStudent = GetStudentById(id);
                acSightDbContext.Students.Remove(deleteStudent);
                acSightDbContext.SaveChanges();
            }
        }

        public List<Student> GetAll()
        {
            using (var acSightDbContext = new AcSightDbContext())
            {
                var students = acSightDbContext.Students.ToList();
                return students;
            }
        }

        public List<Student> GetStudentByAge(int age)
        {
            using (var acSightDbContext = new AcSightDbContext())
            {
                var students = acSightDbContext.Students
                    .Where(s => s.Age == age).ToList();
                return students;
            }
        }

        public Student GetStudentById(int id)
        {
            using (var acSightDbContext = new AcSightDbContext())
            {
                return acSightDbContext.Students.Find(id);
            }
        }

        public Student UpdateStudent(Student student)
        {
            using (var acSightDbContext = new AcSightDbContext())
            {
                acSightDbContext.Students.Update(student);
                acSightDbContext.SaveChanges();
                return student;
            }
        }
    }
}
