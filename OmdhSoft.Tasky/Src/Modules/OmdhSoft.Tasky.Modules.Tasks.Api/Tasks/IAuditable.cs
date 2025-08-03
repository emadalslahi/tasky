namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks;

public interface IAuditable<TId>
{
    TId Id { get; }
}
