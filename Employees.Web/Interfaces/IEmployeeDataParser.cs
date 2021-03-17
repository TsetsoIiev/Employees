using System.Collections.Generic;
using Employees.Web.Models;

namespace Employees.Web.Interfaces
{
    public interface IEmployeeDataParser
    {
        Dictionary<int, List<TimePeriodForProject>> ParseData(IEnumerable<EmployeeCreate> data);
    }
}