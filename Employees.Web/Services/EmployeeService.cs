using System;
using System.Collections.Generic;
using System.Linq;
using Employees.Web.Interfaces;
using Employees.Web.Models;

namespace Employees.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDataParser _employeeDataParser;

        public EmployeeService(IEmployeeDataParser employeeDataParser)
        {
            _employeeDataParser = employeeDataParser;
        }
        
        public LongestCoworkers FindLongestCoworkers(Dictionary<int, List<Employee>> employees)
        {
            var longestCoworkersForCompanies = employees
                .Select(x => _employeeDataParser.GetLongestCoworkersForCompany(x.Value, x.Key))
                .Where(x => x is not null);

            if (longestCoworkersForCompanies is not null && longestCoworkersForCompanies.Any())
            {
                return longestCoworkersForCompanies
                    .OrderByDescending(x => x.TotalDaysWorked)
                    .FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}