using Business.Services.Interface;
using Common.Exceptions;
using Common.Models;
using DataAccess.Repositories.Interface;

namespace Business.Services;

public class HeartbeatService : IHeartbeatService
{
    private readonly IHeartbeatRepository _heartbeatRepository;

    public HeartbeatService(IHeartbeatRepository heartbeatRepository)
    {
        _heartbeatRepository = heartbeatRepository;
    }

    public bool Add(Heartbeat heartbeat)
    {
        try
        {
            return _heartbeatRepository.Add(heartbeat); 
        }
        catch (Exception ex)
        {
            throw new ServiceException("Error while adding heartbeat", ex);
        }
    }

    public bool AddRange(IEnumerable<Heartbeat> heartbeats)
    {
        try
        {
            return _heartbeatRepository.AddRange(heartbeats);
        }
        catch (Exception ex)
        {
            throw new ServiceException("Error while adding heartbeats", ex);
        }
    }

    public bool Update(Heartbeat heartbeat)
    {
        try
        {
            return _heartbeatRepository.Update(heartbeat);
        }
        catch (Exception ex)
        {
            throw new ServiceException("Error while updating heartbeat", ex);
        }
    }

    public bool Remove(int id)
    {
        try
        {
            return _heartbeatRepository.Remove(id);
        }
        catch (Exception ex)
        {
            throw new ServiceException("Error while removing heartbeat", ex);
        }
    }

    public Heartbeat Get(int id)
    {
        try
        {
            return _heartbeatRepository.Get(id);
        }
        catch (Exception ex)
        {
            throw new ServiceException("Error while getting heartbeat", ex);
        }
    }

    public IEnumerable<Heartbeat> GetAll()
    {
        try
        {
            return _heartbeatRepository.GetAll();
        }
        catch (Exception ex)
        {
            throw new ServiceException("Error while getting all heartbeats", ex);
        }
    }
}
