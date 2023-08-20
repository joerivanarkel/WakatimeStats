using System.Text.Json;

namespace Common.Exceptions;

public class ServiceException : BaseException
{
    public ServiceException() { }
    public ServiceException(string message) : base(message) { }
    public ServiceException(string message, Exception innerException) : base(message, innerException) { }
}
