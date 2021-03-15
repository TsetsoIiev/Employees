using System;

namespace Employees.Web.Models
{
    public class Employee
    {
        public Employee(int employeeId, DateTime dateFrom, DateTime dateTo)
        {
            EmployeeId = employeeId;
            DateFrom = dateFrom;
            DateTo = dateTo;
            DaysWorked = (dateTo - dateFrom).Days;
        }

        public int EmployeeId { get; }

        public DateTime DateFrom { get; }

        public DateTime DateTo { get; }

        public int DaysWorked { get; }
    }
}