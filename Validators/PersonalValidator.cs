using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
    public class PersonalValidator: AbstractValidator<Personal>
    {
        public PersonalValidator()
        {
            RuleFor(x => x.PersonalTitle).NotNull().NotEmpty().WithMessage("Personal Title is Not Null!");
            RuleFor(x => x.Age).NotNull().NotEmpty().WithMessage("Age is Not Null!");
            RuleFor(x => x.FullName).NotNull().NotEmpty().WithMessage("Full Name is Not Null!");
            
        }
    }
}
