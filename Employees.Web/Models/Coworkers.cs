using System.Collections.Generic;

namespace Employees.Web.Models
{
    public class Coworkers
    {
        public int FirstEmployeeId { get; set; }

        public int SecondEmployeeId { get; set; }

        public int TotalDaysWorked { get; set; }

        public HashSet<int> ProjectIdsWorkedOn { get; set; } = new();
    }
}