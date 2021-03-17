using System.Collections.Generic;
using System.Linq;
using Employees.Web.Interfaces;
using Employees.Web.Models;
using MoreLinq;

namespace Employees.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDateTimeParser _dateTimeParser;

        public EmployeeService(IDateTimeParser dateTimeParser)
        {
            _dateTimeParser = dateTimeParser;
        }

        public Coworkers FindLongestCoworkers(Dictionary<int, List<TimePeriodForProject>> employeesDictionary)
        {
            var coworkers = new List<Coworkers>();
            var otherEmployees = employeesDictionary.Keys.ToList();
            foreach (var (employeeId, timePeriods) in employeesDictionary)
            {
                otherEmployees.Remove(employeeId);

                foreach (var otherEmployeeId in otherEmployees)
                {
                    var coworkerPair = new Coworkers(employeeId, otherEmployeeId);
                    
                    foreach (var currentProject in timePeriods)
                    {
                        foreach (var otherEmpProject in employeesDictionary[otherEmployeeId])
                        {
                            if (currentProject.ProjectId != otherEmpProject.ProjectId || !_dateTimeParser.AreOverlappingTimes(currentProject, otherEmpProject))
                            {
                                continue;
                            }
                            
                            var timeWorkedTogether = _dateTimeParser.GetDaysWorkedTogether(currentProject, otherEmpProject);

                            coworkerPair.TotalDaysWorked += timeWorkedTogether;
                            coworkerPair.ProjectIdsWorkedOn.Add(currentProject.ProjectId);

                            //We assume that there is only one pair of coworkers per project
                            break;
                        }
                    }
                    
                    coworkers.Add(coworkerPair);
                }
            }

            //We assume that there is only one pair of coworkers with highest time worked together
            return coworkers.MaxBy(x => x.TotalDaysWorked).FirstOrDefault();
        }
    }
}