namespace Tasky.Modules.Tasks.Domain.ValueObjects;

public sealed record TaskDescription
{
    public string Value { get; }

    private TaskDescription(string value)
    {
        Value = value;
    }

    public static TaskDescription From(string value) => new TaskDescription(value ?? string.Empty);

    public override string ToString() => Value;

    public static implicit operator string(TaskDescription description) => description.Value;
    public static implicit operator TaskDescription(string value) => From(value);
}
