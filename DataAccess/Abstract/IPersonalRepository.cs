using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    // In this abstract class, we have categorized the CRUD operations we will do on our database table.
    public interface IPersonalRepository
    {
        List<Personal> GetAllPersonals();
        List<Personal> GetPersonalByTitle(string title);
        List<Personal> GetPassivePersonals();
        Personal GetPersonalById(int id);
        Personal CreatePersonal(Personal personal);
        Personal UpdatePersonal(Personal personal);
        void DeletePersonal(int id);
    }
}
