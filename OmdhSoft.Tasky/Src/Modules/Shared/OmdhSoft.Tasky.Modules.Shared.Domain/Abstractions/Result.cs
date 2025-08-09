using System.Diagnostics.CodeAnalysis;

namespace OmdhSoft.Tasky.Modules.Shared.Domain.Abstractions;

public class Result
{
    public Result(bool isSuccess,Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error",nameof(error));
        }
        IsSuccess = isSuccess;
        Error = error;
    }
    
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public Error Error { get; }
    public static Result Success()=>new (true,Error.None);
    public static Result Failure(Error error)=>new (false,error);

    public static Result<Tvlalue> Success<Tvlalue>(Tvlalue value) => new(value, true, Error.None);
    public static Result<Tvlalue> Failure<Tvlalue>(Error error) => new(default,false, error);
    public static implicit operator bool(Result result) => result.IsSuccess;
}

public class Result<TValue> :Result
{
    private readonly TValue? _value;

    public Result(TValue? value , bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }
    [NotNull]
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can't be accessed.");

    public static implicit operator Result<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);

    public static implicit operator Result<TValue>(Error error) => new(default, false, error);

}
 