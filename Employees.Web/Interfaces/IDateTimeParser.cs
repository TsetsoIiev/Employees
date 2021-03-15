using System;
using Employees.Web.Enums;
using Employees.Web.Models;

namespace Employees.Web.Interfaces
{
    public interface IDateTimeParser
    {
        DateTime ParseDate(string date, DateType type);

        bool AreOverlappingTimes(Employee employee1, Employee employee2);

        int GetDaysWorkedTogether(Employee employee1, Employee employee2);
    }
}