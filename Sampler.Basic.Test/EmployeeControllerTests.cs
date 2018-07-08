using NSubstitute;
using Sampler.Basic.Controllers;
using Sampler.Basic.Services;
using Xunit;

namespace Sampler.Basic.Test
{
    public class EmployeeControllerTests
    {
        private readonly EmployeeController target;

        public EmployeeControllerTests()
        {
            IEmployeeService employeeService = Substitute.For<IEmployeeService>();
            //target = new EmployeeController(employeeService);
        }

        [Fact]
        public void IndexShouldLogInfo()
        {
            target.Index();
        }
    }
}
