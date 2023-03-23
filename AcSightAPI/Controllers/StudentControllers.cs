using Business.Abstract;
using Contracts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AcSightAPI.Controllers
{
    [Route("app/acsight")]
    [ApiController]
    public class StudentControllers : ControllerBase
    {
        private IStudentService _studentService;
        private ILoggerManager _loggerManager;

        public StudentControllers(IStudentService studentService, ILoggerManager loggerManager)
        {
            _studentService = studentService;
            _loggerManager = loggerManager;
        }

        [HttpGet("get-all-students")]
        public List<Student> GetStudents()
        {
            try
            {
                _loggerManager.LogInfo("Students Listed!");
                return _studentService.GetAll();
            }
            catch (System.Exception e)
            {
                _loggerManager.LogError("Students Cannot Listed! " +  e.Message);
                throw;
            }
        }

        [HttpPost("add-new-student")]
        public Student AddStudent(Student student)
        {
            try
            {
                _loggerManager.LogInfo(student.FullName + " Named Student Added to DB");
                return _studentService.CreateStudent(student);
            }
            catch (System.Exception e)
            {
                _loggerManager.LogError("New Student Cannot Add to DB " + e.Message);
                throw;
            }
        }
    }
}
