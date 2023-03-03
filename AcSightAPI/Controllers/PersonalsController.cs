
using Business.Abstract;
using Business.Concrete;
using Contracts;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("acsight/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonalControllers : ControllerBase
    {
        private IPersonalService _personalService;
        private ILoggerManager _loggerManager;
        public PersonalControllers(IPersonalService personalService, ILoggerManager loggerManager)
        {
            _personalService = personalService;
            _loggerManager = loggerManager;
        }

        [HttpGet("getall")]
        public List<Personal> Get()
        {
            try
            {
                _loggerManager.LogInfo("Project Has Been Run!");
                return _personalService.GetAllPersonals();
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError("Project Has Been Crashed!!!" + ex.Message);
                throw;
            }
               
        }

        [HttpGet("getpassivepersonals")]
        public List<Personal> GetPassivePersonals()
        {
            try
            {
                _loggerManager.LogInfo("Passive Personals Listed!");
                return _personalService.GetPassivePersonals();
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError("Passive Personals Cannot Listed!!! " + ex.Message);
                throw;
            }
        }

        [HttpGet("filterbytitle/{title}")]
        public List<Personal> GetByTitle([FromQuery] Personal personal, string title)
        {
            try
            {
                _loggerManager.LogInfo("Data Filtered by " + title + " Title Name");
                return _personalService.GetPersonalByTitle(title);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError("Data Cannot Filter by Personal Title " + ex.Message);
                throw;
            }
            
        }

        [HttpGet("getid/{id}")]
        public Personal GetById(int id)
        {
            try
            {
                _loggerManager.LogInfo("All Data Listed by Id!");
                return _personalService.GetPersonalById(id);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError("All Data Cannot Listed by Id!!! " + ex.Message);
                throw;
            }
            
        }

        [HttpPost("add")]
        public Personal Add([FromBody] Personal personal)
        {
            try
            {
                _loggerManager.LogInfo(personal.FullName + " Named Personal Added to DB!");
                return _personalService.CreatePersonal(personal);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError(personal.FullName + " Named Personal Cannot Added to DB!");
                throw;
            }
            
        }

        [HttpPut("update")]
        public Personal Update([FromBody] Personal personal)
        {
            try
            {
                _loggerManager.LogInfo(personal.FullName + " Named Personal Updated!");
                return _personalService.UpdatePersonal(personal);
            }
            catch (System.Exception)
            {

                _loggerManager.LogError(personal.FullName + " Named Personal Cannot Updated!!!");
                throw;
            }
            
        }

        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            try
            {
                _loggerManager.LogInfo("User With " + id + " Has Been Deleted!");
                _personalService.DeletePersonal(id);
            }
            catch (System.Exception)
            {
                _loggerManager.LogError("User With " + id + " Cannot Deleted!");
                throw;
            }
             
        }
    }
}
