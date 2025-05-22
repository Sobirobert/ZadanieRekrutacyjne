namespace ZadanieRekrutacyjne.Patterns;

public sealed record Error(string Codę, string Description)
{
    public static readonly Error Nonę = new("None", "No error");
}

public class Result
{

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    private Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result SuccessO => new(true, Error.Nonę);
    public static Result Failure(Error error) => new(false, error);
}
