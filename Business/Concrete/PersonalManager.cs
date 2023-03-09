using Business.Abstract;
using DataAcces;
using DataAccess;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    //Business rules are written in this class.
    public class PersonalManager : IPersonalService
    {
        private IPersonalRepository _personalRepository;
        private Personal _personal;
        private AcSightDbContext _acSightDbContext;

        public PersonalManager()
        {
            _personalRepository = new PersonalRepository();
            _personal = new Personal();
            _acSightDbContext = new AcSightDbContext();
        }
        public Personal CreatePersonal(Personal personal) 
        {
            // FullName, PersonalComment, PersonalTitle fields cannot be null.
            if(personal.FullName == null || personal.PersonalComment == null || personal.PersonalTitle == null)
            {
                return null;
            }
            return _personalRepository.CreatePersonal(personal);
        }

        public void DeletePersonal(int id)
        {
            _personalRepository.DeletePersonal(id);
        }

        public List<Personal> GetAllPersonals()
        {
            return _personalRepository.GetAllPersonals();
        }

        public List<Personal> GetPassivePersonals()
        {
           return _personalRepository.GetPassivePersonals();
        }

        public Personal GetPersonalById(int id)
        {
           return _personalRepository.GetPersonalById(id);
        }

        public List<Personal> GetPersonalByTitle(string title)
        {
            return _personalRepository.GetPersonalByTitle(title);
        }

        public Personal UpdatePersonal(Personal personal)
        {
           return _personalRepository.UpdatePersonal(personal);
        }
    }
}
