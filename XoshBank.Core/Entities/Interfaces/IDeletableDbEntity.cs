using System;

namespace XoshBank.Entities.Interfaces
{
    public interface IDeletableDbEntity : IDbEntity
    {
        DateTime? DeletedAt { get; set; }
    }
}
