namespace Tasky.Modules.Tasks.Domain.ValueObjects;

public readonly record struct TaskPriority
{
    public int Value { get; }

    private TaskPriority(int value)
    {
        Value = value;
    }

    public static TaskPriority Low { get; } = new(0);
    public static TaskPriority Medium { get; } = new(1);
    public static TaskPriority High { get; } = new(2);
    public static TaskPriority Urgent { get; } = new(3);

    public static TaskPriority From(int value) => value switch
    {
        0 => Low,
        1 => Medium,
        2 => High,
        3 => Urgent,
        _ => throw new ArgumentOutOfRangeException(nameof(value), "Invalid priority value")
    };

    public override string ToString() => Value.ToString();

    public static implicit operator int(TaskPriority priority) => priority.Value;
    public static implicit operator TaskPriority(int value) => From(value);
}
