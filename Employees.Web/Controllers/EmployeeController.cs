using Employees.Web.Interfaces;
using Employees.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeDataParser _employeeDataParser;

        public EmployeeController(IEmployeeService employeeService, IEmployeeDataParser employeeDataParser)
        {
            _employeeService = employeeService;
            _employeeDataParser = employeeDataParser;
        }

        [HttpPost]
        [Route("/GetLongestCoworkers")]
        public IActionResult GetLongestCoworkers([FromBody]EmployeeCreate[] data)
        {
            var employees = _employeeDataParser.ParseEmployees(data);
            var longestCoworkers = _employeeService.FindLongestCoworkers(employees);

            return longestCoworkers is not null
                ? Ok(longestCoworkers)
                : BadRequest(Strings.WrongDataFormat);
        }
    }
}