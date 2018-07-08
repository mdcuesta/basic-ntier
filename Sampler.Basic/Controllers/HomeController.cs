using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sampler.Basic.Models;
using Sampler.Basic.Services;
using Sampler.Basic.Services.Dto;
using Microsoft.Extensions.DependencyInjection;

namespace Sampler.Basic.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public HomeController(IEmployeeService employeeService, 
                              IHttpContextAccessor httpContextAccessor,
                             IServiceProvider serviceProvider)
        {
            this.employeeService = employeeService;
            this.httpContextAccessor = httpContextAccessor;

            IEmployeeService employeeService1 = serviceProvider
                                                    .GetService<IEmployeeService>();
        }

        public IActionResult Index()
        {
            IEnumerable<EmployeeDto> employees = this.employeeService.GetEmployees();
            return View();
        }

        public IActionResult About()
        {
            var userId = int.Parse(User.Identity.Name);//this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            this.employeeService.AddNewEmployee(new EmployeeDto
            {
                USerId = userId,
            });
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
