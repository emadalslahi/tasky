namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks;

public interface IAuditable<TKey>
{
    TKey Id { get; }
}
