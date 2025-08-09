namespace OmdhSoft.Tasky.Modules.Shared.Domain.Auditing;

public interface IFullAuditable<TId> : IAuditable<TId>
{
    DateTime CreatedAt { get;   }
    DateTime? UpdatedAt { get;  }
    DateTime? DeletedAt { get;  }
    Guid CreatedByUserId { get;  }
    Guid? UpdatedByUserId { get;  }
    Guid? DeletedByUserId { get;  }
}
