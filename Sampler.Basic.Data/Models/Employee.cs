using System;

namespace Sampler.Basic.Data.Models
{
    public class Employee : BaseEntity
    {
        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Sex { get; set; }

        public DateTime? Birthday { get; set; }

        public string Position { get; set; }

        public string Comment { get; set; }

        public bool IsActive { get; set; }
    }
}
