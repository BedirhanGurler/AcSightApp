using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    /*In this abstract class of our business layer,
    we categorize the business rules to be made in the concrete class. */
    public interface IPersonalService
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
