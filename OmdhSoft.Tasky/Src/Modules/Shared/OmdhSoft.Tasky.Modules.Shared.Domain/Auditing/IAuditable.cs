namespace OmdhSoft.Tasky.Modules.Shared.Domain.Auditing;

public interface IAuditable<TKey>
{
    TKey Id { get; }
}
