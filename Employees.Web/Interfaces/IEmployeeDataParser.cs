using System.Collections.Generic;
using Employees.Web.Models;

namespace Employees.Web.Interfaces
{
    public interface IEmployeeDataParser
    {
        Dictionary<int, List<Employee>> ParseEmployees(EmployeeCreate[] data);

        LongestCoworkers GetLongestCoworkersForCompany(List<Employee> employees, int projectId);
    }
}