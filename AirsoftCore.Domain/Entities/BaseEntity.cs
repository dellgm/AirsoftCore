using System;

namespace AirsoftCore.Domain.Entities
{
    public abstract class BaseEntity
    {
        public DateTime? DateCreated { get; set; }
        public DateTime? DateEdited { get; set; }
    }
}
