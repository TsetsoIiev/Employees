using System.Collections.Generic;
using Employees.Web.Models;

namespace Employees.Web.Interfaces
{
    public interface IEmployeeService
    {
        LongestCoworkers FindLongestCoworkers(Dictionary<int, List<Employee>> employees);
    }
}