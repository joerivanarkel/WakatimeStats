namespace Common.Exceptions;

public class APIExeptionModel
{
    public required string Message { get; set; }
    public string? Source { get; set; }
    public APIExeptionModel? InnerException { get; set; }
}