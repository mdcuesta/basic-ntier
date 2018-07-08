using Sampler.Basic.Core;
using Sampler.Basic.Data.Models;

namespace Sampler.Basic.Data.Dapper
{
    public class EmployeeRepository : BaseRepository<Employee>,
        IEmployeeRepository
    {
        public EmployeeRepository(IConnectionManager connectionManager,
                                 IUserContext userContext) 
            : base(connectionManager, userContext)
        {
        }
    }
}
