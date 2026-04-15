using System;

namespace XoshBank.Core.Entities.Interfaces
{
    public interface IDeletableDbEntity : IDbEntity
    {
        DateTime? DeletedAt { get; set; }
    }
}
