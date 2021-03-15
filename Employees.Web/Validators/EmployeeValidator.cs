using System;
using Employees.Web.Models;
using FluentValidation;

namespace Employees.Web.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.EmployeeId)
                .GreaterThan(0);

            RuleFor(x => x.DateFrom)
                .GreaterThan(new DateTime());
            
            RuleFor(x => x.DateTo)
                .GreaterThan(new DateTime());
        }
    }
}