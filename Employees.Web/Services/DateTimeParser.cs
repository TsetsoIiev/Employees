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

        public bool AreOverlappingTimes(TimePeriodForProject project1, TimePeriodForProject project2)
        {
            return project1.DateFrom <= project2.DateTo && project2.DateFrom <= project1.DateTo;
        }

        public int GetDaysWorkedTogether(TimePeriodForProject project1, TimePeriodForProject project2)
        {
            if (project1.DateFrom > project2.DateFrom)
            {
                return GetDaysWorkedTogether(project2, project1);
            }

            return project1.DateTo > project2.DateTo 
                ? (project2.DateTo - project2.DateFrom).Days 
                : (project1.DateTo - project2.DateFrom).Days;
        }
    }
}