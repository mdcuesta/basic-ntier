using System.Collections.Generic;
using Sampler.Basic.Services.Dto;

namespace Sampler.Basic.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees();

        void AddNewEmployee(EmployeeDto employeeDto);
    }
}
