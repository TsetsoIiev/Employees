using Newtonsoft.Json;

namespace Employees.Web.Models
{
    [JsonObject]
    public class EmployeeCreate
    {
        [JsonConstructor]
        public EmployeeCreate()
        {
            
        }
        
        [JsonProperty("employeeId")]
        public string EmployeeId { get; set; }

        [JsonProperty("projectId")]
        public string ProjectId { get; set; }

        [JsonProperty("dateFrom")]
        public string DateFrom { get; set; }

        [JsonProperty("dateTo")]
        public string DateTo { get; set; }
    }
}