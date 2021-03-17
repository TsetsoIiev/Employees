using System;
using Employees.Web.Enums;
using Employees.Web.Models;

namespace Employees.Web.Interfaces
{
    public interface IDateTimeParser
    {
        DateTime ParseDate(string date, DateType type);

        bool AreOverlappingTimes(TimePeriodForProject project1, TimePeriodForProject project2);

        int GetDaysWorkedTogether(TimePeriodForProject project1, TimePeriodForProject project2);
    }
}