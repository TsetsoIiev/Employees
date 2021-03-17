using System;
using Employees.Web.Models;
using FluentValidation;

namespace Employees.Web.Validators
{
    public class TimePeriodForProjectValidator : AbstractValidator<TimePeriodForProject>
    {
        public TimePeriodForProjectValidator()
        {
            RuleFor(x => x.ProjectId)
                .GreaterThan(0);

            RuleFor(x => x.DateFrom)
                .GreaterThan(new DateTime());
            
            RuleFor(x => x.DateTo)
                .GreaterThan(new DateTime());
        }
    }
}