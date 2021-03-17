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

        public Dictionary<int, List<TimePeriodForProject>> ParseData(IEnumerable<EmployeeCreate> data)
        {
            return data
                .GroupBy(
                    x => x.EmployeeId,
                    x => new {x.ProjectId, x.DateFrom, x.DateTo},
                    (emp, proj) =>
                        new KeyValuePair<int, List<TimePeriodForProject>>(int.Parse(emp), proj.Select(x =>
                                new TimePeriodForProject(
                                    int.Parse(x.ProjectId),
                                    _dateTimeParser.ParseDate(x.DateFrom, DateType.From),
                                    _dateTimeParser.ParseDate(x.DateTo, DateType.To))).ToList()
                        ))
                .ToDictionary(k => k.Key, v => v.Value);
        }
    }
}