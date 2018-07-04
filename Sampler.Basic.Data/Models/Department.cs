namespace Sampler.Basic.Data.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }

        public string Comment { get; set; }

        public bool IsActive { get; set; }
    }
}
