using System;

namespace Employees.Web.Models
{
    public class TimePeriodForProject
    {
        public TimePeriodForProject(int projectId, DateTime dateFrom, DateTime dateTo)
        {
            ProjectId = projectId;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        public int ProjectId { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}