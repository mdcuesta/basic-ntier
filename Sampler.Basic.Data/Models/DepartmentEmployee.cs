namespace Sampler.Basic.Data.Models
{
    public class DepartmentEmployee : BaseEntity
    {
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
