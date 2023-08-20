using Business.Services.Interface;
using Common.Exceptions;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1;

/// <summary>
/// The heartbeat controller
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class HeartbeatController : BaseController
{
    private IHeartbeatService HeartbeatService { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    public HeartbeatController(IHeartbeatService heartbeatService, ILogger<HeartbeatController> logger) : base(logger)
    {
        HeartbeatService = heartbeatService;
    }


    /// <summary>
    /// Get all heartbeats from the database
    /// </summary>
    /// <returns>A list of heartbeats</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Get()
    {
        try
        {
            Logger.LogInformation("Getting all heartbeats");
            return Ok(HeartbeatService.GetAll()); 
        }
        catch (BaseException ex)
        {
            Logger.LogError(ex, "Error getting all heartbeats");
            return BadRequest(ex.Filter());
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error getting all heartbeats");
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get a specific heartbeat from the database
    /// </summary>
    /// <param name="id">The id of the heartbeat</param>
    /// <returns>The specific heartbeat</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        try
        {
            Logger.LogInformation($"Getting heartbeat with id {id}");
            var heartbeat = HeartbeatService.Get(id);
            if (heartbeat == null)
                return NullBadRequest();
            
            return Ok(heartbeat);
            
        }
        catch (BaseException ex)
        {
            Logger.LogError(ex, $"Error getting heartbeat with id {id}");
            return BadRequest(ex.Filter());
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, $"Error getting heartbeat with id {id}");
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Add a heartbeat to the database
    /// </summary>
    /// <param name="heartbeat">The heartbeat to add</param>
    /// <returns>The added heartbeat</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Post([FromBody] Heartbeat heartbeat)
    {
        try
        {
            if (heartbeat == null)
                return NullBadRequest();
            
            if (!ModelState.IsValid)
                return InvalidBadRequest(nameof(heartbeat));
            

            HeartbeatService.Add(heartbeat);
            return CreatedAtAction(nameof(Get), new { id = heartbeat.Id }, heartbeat);
        }
        catch (BaseException ex)
        {
            Logger.LogError(ex, "Error adding heartbeat");
            return BadRequest(ex.Filter());
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error adding heartbeat");
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Add a range of heartbeats to the database
    /// </summary>
    /// <param name="heartbeats">The heartbeats to add</param>
    /// <returns>The added heartbeats</returns>
    [HttpPost("range")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult PostRange([FromBody] IEnumerable<Heartbeat> heartbeats)
    {
        try
        {
            if (heartbeats == null)
                return NullBadRequest();

            if (!ModelState.IsValid)
                return InvalidBadRequest(nameof(heartbeats));

            HeartbeatService.AddRange(heartbeats);
            return CreatedAtAction(nameof(Get), heartbeats);
        }
        catch (BaseException ex)
        {
            Logger.LogError(ex, "Error adding heartbeats");
            return BadRequest(ex.Filter());
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error adding heartbeats");
            return BadRequest(ex.Message);
        }
    }   

    /// <summary>
    /// Update a heartbeat in the database
    /// </summary>
    /// <param name="id">The id of the heartbeat</param>
    /// <param name="heartbeat">The desired heartbeat data</param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Patch(int id, [FromBody] Heartbeat heartbeat)
    {
        try
        {
            if (heartbeat == null)
                return NullBadRequest();
            
            if (!ModelState.IsValid)
                return InvalidBadRequest(nameof(heartbeat));
            
            if (id != heartbeat.Id)
                return BadRequest();
            
            if (HeartbeatService.Get(id) == null)
                return NotFound();
            
            HeartbeatService.Update(heartbeat);
            return NoContent();
        }
        catch (BaseException ex)
        {
            Logger.LogError(ex, $"Error updating heartbeat with id {id}");
            return BadRequest(ex.Filter());
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, $"Error updating heartbeat with id {id}");
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Delete a heartbeat from the database
    /// </summary>
    /// <param name="id">The id of the heartbeat</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        try
        {
            if (HeartbeatService.Get(id) == null)
                return NotFound();
        
            HeartbeatService.Remove(id);
            return NoContent();
        }
        catch (BaseException ex)
        {
            Logger.LogError(ex, $"Error deleting heartbeat with id {id}");
            return BadRequest(ex.Filter());
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, $"Error deleting heartbeat with id {id}");
            return BadRequest(ex.Message);
        }
    }


    // Helpers
    private IActionResult NullBadRequest()
    {
        Logger.LogError("Null object");
        return BadRequest();
    }

    private IActionResult InvalidBadRequest(string name)
    {
        Logger.LogError($"{name} is invalid");
        return BadRequest(ModelState);
    }
}
