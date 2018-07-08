using System.Collections.Generic;
using Sampler.Basic.Data.Models;

namespace Sampler.Basic.Data
{
    public interface IEmployeeRepository
    {
        Employee Get(int id);

        IEnumerable<Employee> GetAll();

        int Insert(Employee employee);

        bool Update(Employee employee);

        bool Delete(Employee employee);
    }
}
