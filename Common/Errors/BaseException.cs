using System.Text.Json;

namespace Common.Exceptions;

public class BaseException : Exception
{
    public BaseException() { }
    public BaseException(string message) : base(message) { }
    public BaseException(string message, Exception innerException) : base(message, innerException) { }

    public APIExeptionModel Filter()
    {
        APIExeptionModel FilterInnerException(Exception? ex)
        {
            if (ex == null)
                return null!;

            if (ex.InnerException is BaseException)
                return Filter();

            return new APIExeptionModel { Message = ex.Message, Source = ex.Source, InnerException = FilterInnerException(ex.InnerException) };            
        }

        var model = new APIExeptionModel
        {
            Message = Message,
            Source = Source,
            InnerException = FilterInnerException(InnerException)
        };

        return model;
    }

}
