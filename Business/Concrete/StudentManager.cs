using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private IStudentReporsitory _studentRepository;
        public StudentManager()
        {
            _studentRepository = new StudentRepository();
        }

        public Student CreateStudent(Student student)
        {
            return _studentRepository.CreateStudent(student);
        }

        public void DeleteStudent(int id)
        {
             _studentRepository.DeleteStudent(id);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public List<Student> GetStudentByAge(int age)
        {
            return _studentRepository.GetStudentByAge(age);
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        public Student UpdateStudent(Student student)
        {
            return _studentRepository.UpdateStudent(student);
        }
    }
}
