using System.Collections.Generic;

namespace Employees.Web.Models
{
    public class Coworkers
    {
        public Coworkers(int firstEmployeeId, int secondEmployeeId)
        {
            FirstEmployeeId = firstEmployeeId;
            SecondEmployeeId = secondEmployeeId;
            TotalDaysWorked = 0;
            ProjectIdsWorkedOn = new HashSet<int>();
        }

        public int FirstEmployeeId { get; set; }

        public int SecondEmployeeId { get; set; }

        public int TotalDaysWorked { get; set; }

        public HashSet<int> ProjectIdsWorkedOn { get; set; } = new();
    }
}