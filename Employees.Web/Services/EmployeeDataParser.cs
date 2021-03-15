using System.Collections.Generic;
using System.Linq;
using Employees.Web.Enums;
using Employees.Web.Interfaces;
using Employees.Web.Models;

namespace Employees.Web.Services
{
    public class EmployeeDataParser : IEmployeeDataParser
    {
        private readonly IDateTimeParser _dateTimeParser;

        public EmployeeDataParser(IDateTimeParser dateTimeParser)
        {
            _dateTimeParser = dateTimeParser;
        }

        public Dictionary<int, List<Employee>> ParseEmployees(EmployeeCreate[] data)
        {
            var result = new Dictionary<int, List<Employee>>();

            foreach (var employee in data)
            {
                int.TryParse(employee.ProjectId, out int projectId);
                int.TryParse(employee.EmployeeId, out int employeeId);

                var newEmployee = new Employee(
                    employeeId,
                    _dateTimeParser.ParseDate(employee.DateFrom, DateType.From),
                    _dateTimeParser.ParseDate(employee.DateTo, DateType.To));
                
                if (!result.ContainsKey(projectId))
                {
                    result.Add(projectId, new List<Employee>(){ newEmployee });
                }
                else
                {
                    result[projectId].Add(newEmployee);
                }
            }

            return result;
        }

        public LongestCoworkers GetLongestCoworkersForCompany(List<Employee> employees, int projectId)
        {
            var result = new List<LongestCoworkers>();
            for (var i = 0; i < employees.Count; i++)
            {
                var employee = employees[i];

                for (var j = i + 1; j < employees.Count; j++)
                {
                    var otherEmployee = employees[j];
                    var areOverlappingTimes = _dateTimeParser.AreOverlappingTimes(employee, otherEmployee);
                    if (!areOverlappingTimes)
                    {
                        continue;
                    }

                    if (employee.EmployeeId == otherEmployee.EmployeeId)
                    {
                        continue;
                    }

                    var daysWorkedTogether = _dateTimeParser.GetDaysWorkedTogether(employee, otherEmployee);

                    var previousWorkTogether = result
                        .FirstOrDefault(x => 
                            (x.FirstEmployeeId == employee.EmployeeId && x.SecondEmployeeId == otherEmployee.EmployeeId)
                            || (x.FirstEmployeeId == otherEmployee.EmployeeId && x.SecondEmployeeId == employee.EmployeeId));

                    if (previousWorkTogether is null)
                    {
                        var longestCoworkers = new LongestCoworkers()
                        {
                            FirstEmployeeId = employee.EmployeeId,
                            SecondEmployeeId = otherEmployee.EmployeeId,
                            TotalDaysWorked = daysWorkedTogether
                        };

                        longestCoworkers.ProjectIdsWorkedOn.Add(projectId);

                        result.Add(longestCoworkers);

                    }
                    else if (previousWorkTogether.FirstEmployeeId == employee.EmployeeId || previousWorkTogether.FirstEmployeeId == otherEmployee.EmployeeId
                        || previousWorkTogether.SecondEmployeeId == employee.EmployeeId || previousWorkTogether.SecondEmployeeId == otherEmployee.EmployeeId)
                    {
                        continue;
                    }
                    else
                    {
                        previousWorkTogether.TotalDaysWorked += daysWorkedTogether;
                        previousWorkTogether.ProjectIdsWorkedOn.Add(projectId);
                    }
                }
            }

            return result
                .OrderByDescending(x => x.TotalDaysWorked)
                .FirstOrDefault();
        }
    }
}