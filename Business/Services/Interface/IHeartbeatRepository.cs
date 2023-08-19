using Common.Models;

namespace Business.Services.Interface;

public interface IHeartbeatService
{
    bool Add(Heartbeat heartbeat);
    bool AddRange(IEnumerable<Heartbeat> heartbeats);
    bool Update(Heartbeat heartbeat);
    bool Remove(int id);
    Heartbeat Get(int id);
    IEnumerable<Heartbeat> GetAll();
}
