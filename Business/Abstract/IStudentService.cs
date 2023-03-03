using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentService
    {
        List<Student> GetAll();
        List<Student> GetStudentByAge(int age);
        Student GetStudentById(int id);
        Student CreateStudent(Student student);
        Student UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
