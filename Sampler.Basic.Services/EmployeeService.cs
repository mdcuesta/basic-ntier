using System.Collections.Generic;
using System.Linq;
using Sampler.Basic.Data;
using Sampler.Basic.Data.Models;
using Sampler.Basic.Services.Dto;

namespace Sampler.Basic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            IEnumerable<Employee> employees = this.employeeRepository.GetAll();

            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Birthday = e.Birthday,
                Code = e.Code,
                Comment = e.Comment,
                Position = e.Position,
                Sex = e.Sex,
                IsActive = e.IsActive,
            }).ToList();
        }

        public void AddNewEmployee(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Birthday = employeeDto.Birthday,
                Code = employeeDto.Code,
                Comment = employeeDto.Comment,
                Position = employeeDto.Position,
                Sex = employeeDto.Sex,
                IsActive = employeeDto.IsActive,
            };

            this.employeeRepository.Insert(employee);
        }
    }
}
