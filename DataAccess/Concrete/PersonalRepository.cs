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
    /* In this class, we coded the operations to be done by implementing the CRUD operations
     that we categorized in the Personnel Repository abstract class.*/

    public class PersonalRepository : IPersonalRepository
    {
        // This function add a new data to DB.
        public Personal CreatePersonal(Personal personal)
        {
            using (var acSightDbContext = new AcSightDbContext())
            {
                acSightDbContext.Personals.Add(personal);
                acSightDbContext.SaveChanges();
                return personal;
            }
        }

        // This function deletes from the database by id.
        public void DeletePersonal(int id)
        {
            using (var acSightDbContext = new AcSightDbContext())
            {
                var deletePersonal = GetPersonalById(id);
                acSightDbContext.Personals.Remove(deletePersonal);
                acSightDbContext.SaveChanges();
            }
        }

        // This function list active personals.
        public List<Personal> GetAllPersonals()
        {
            // Just List with IsActive field -1-. IsActive 1 = Active Personal
            using (var acSightDbContext = new AcSightDbContext())
            {
                var personals = acSightDbContext.Personals
                    .Where(p => p.IsActive == 1).ToList();
                return personals;
            }
        }

        // This function list data by Title and IsActive field 1.
        public List<Personal> GetPersonalByTitle(string title)
        {
            using (var acSightDbContext = new AcSightDbContext())
            {
                var personals = acSightDbContext.Personals
                    .Where(p => p.IsActive == 1 && p.PersonalTitle == title).ToList();
                return personals;
            }
           
        }

        // This function list data by id.
        public Personal GetPersonalById(int id)
        {
            using (var acSightDbContext = new AcSightDbContext())
            {
                return acSightDbContext.Personals.Find(id);
            }
        }

        //This function update data.
        public Personal UpdatePersonal(Personal personal)
        {
            using (var acSightDbContext = new AcSightDbContext())
            {
                acSightDbContext.Personals.Update(personal);
                acSightDbContext.SaveChanges();
                return personal;
            }
        }

        // This function list passive personals.
        public List<Personal> GetPassivePersonals()
        {
            using (var acSightDbContext = new AcSightDbContext())
            {
                var personals = acSightDbContext.Personals
                    .Where(p => p.IsActive == 0).ToList();
                return personals;
            }
        }
    }
}
