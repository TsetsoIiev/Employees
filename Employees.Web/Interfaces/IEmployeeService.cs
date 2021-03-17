using System.Collections.Generic;
using Employees.Web.Models;

namespace Employees.Web.Interfaces
{
    public interface IEmployeeService
    {
        Coworkers FindLongestCoworkers(Dictionary<int, List<TimePeriodForProject>> employeesDictionary);
    }
}