using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Student: IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string School { get; set; }
        public int Age { get; set; }

    }
}
