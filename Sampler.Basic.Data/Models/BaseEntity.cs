using System;

namespace Sampler.Basic.Data.Models
{
    public abstract class BaseEntity : IAuditable, IIdentifiable
    {
        public int Id { get; set; }

        public int UserCreated { get; set; }

        public DateTime? DateCreated { get; set; }

        public int UserModified { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
