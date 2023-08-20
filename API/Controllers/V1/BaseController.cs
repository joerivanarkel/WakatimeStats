using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1;

public class BaseController : ControllerBase
{
    protected ILogger Logger { get; }

    public BaseController(ILogger logger)
    {
        Logger = logger;
    }

    /// <summary>
    /// Returns a bad request with a message
    /// </summary>
    public override NotFoundResult NotFound()
    {
        Logger.LogError("Object not found");
        return base.NotFound();
    }

    /// <summary>
    /// Returns a bad request with a message
    /// </summary>
    public override NoContentResult NoContent()
    {
        Logger.LogInformation("No content");
        return base.NoContent();
    }
}
