namespace Tasky.Modules.Tasks.Domain.ValueObjects;

public sealed record CommentId
{
    public Guid Value { get; }

    public CommentId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("The ID cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static TaskId New() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();

    public static implicit operator Guid(CommentId id) => id.Value;

    public static implicit operator CommentId(Guid value) => new(value);
}
