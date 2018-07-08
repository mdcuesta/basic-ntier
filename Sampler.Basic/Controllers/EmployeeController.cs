using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sampler.Basic.Services;
using Sampler.Basic.Services.Dto;

namespace Sampler.Basic.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly ILogger logger;

        public EmployeeController(IEmployeeService employeeService, ILogger logger)
        {
            this.employeeService = employeeService;
            this.logger = logger;
        }

        public IEnumerable<EmployeeDto> Index()
        {
            return this.employeeService.GetEmployees();
        }
    }
}
