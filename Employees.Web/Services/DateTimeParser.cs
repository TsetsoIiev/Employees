using System;
using Employees.Web.Enums;
using Employees.Web.Interfaces;
using Employees.Web.Models;

namespace Employees.Web.Services
{
    public class DateTimeParser : IDateTimeParser
    {
        public DateTime ParseDate(string date, DateType type)
        {
            return DateTime.TryParse(date, out var result)
                ? result
                : date == Constants.Strings.Null && type == DateType.To
                    ? DateTime.Now
                    : new DateTime();
        }

        public bool AreOverlappingTimes(Employee employee1, Employee employee2)
        {
            return employee1.DateFrom < employee2.DateTo && employee2.DateFrom < employee1.DateTo;
        }

        public int GetDaysWorkedTogether(Employee employee1, Employee employee2)
        {
            if (employee1.DateFrom > employee2.DateFrom)
            {
                return GetDaysWorkedTogether(employee2, employee1);
            }

            return employee1.DateTo > employee2.DateTo 
                ? (employee2.DateTo - employee2.DateFrom).Days 
                : (employee1.DateTo - employee2.DateFrom).Days;
        }
    }
}