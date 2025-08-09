namespace Tasky.Modules.Tasks.Domain.ValueObjects;

public sealed record TaskTitle
{
    public string Value { get; }

    private TaskTitle(string value)
    {
        Value = value;
    }

    public static TaskTitle From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Title cannot be empty", nameof(value));
        return new TaskTitle(value);
    }

    public override string ToString() => Value;

    public static implicit operator string(TaskTitle title) => title.Value;
    public static implicit operator TaskTitle(string value) => From(value);
}
