namespace Tasky.Modules.Tasks.Domain.ValueObjects;

public sealed record TaskId
{
    public Guid Value { get; }

    public TaskId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Task ID cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static TaskId New() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();

    public static implicit operator Guid(TaskId id) => id.Value;

    public static implicit operator TaskId(Guid value) => new(value);
}
