using System;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.ValueObjects;

public sealed record TaskStatus
{
    public int Value { get; }

    private TaskStatus(int value)
    {
        Value = value;
    }

    public static TaskStatus Pending { get; } = new(0);
    public static TaskStatus Published { get; } = new(1);
    public static TaskStatus Completed { get; } = new(2);
    public static TaskStatus Cancelled { get; } = new(3);
    public static TaskStatus Removed { get; } = new(4);

    public static TaskStatus From(int value) => value switch
    {
        0 => Pending,
        1 => Published,
        2 => Completed,
        3 => Cancelled,
        4 => Removed,
        _ => throw new ArgumentOutOfRangeException(nameof(value), "Invalid status value")
    };

    public override string ToString() => Value.ToString();

    public static implicit operator int(TaskStatus status) => status.Value;
    public static implicit operator TaskStatus(int value) => From(value);
}
