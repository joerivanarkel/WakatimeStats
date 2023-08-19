using Common.Models;

namespace DataAccess.Repositories.Interface;

public interface IHeartbeatRepository
{
    bool Add(Heartbeat heartbeat);
    bool AddRange(IEnumerable<Heartbeat> heartbeats);
    bool Update(Heartbeat heartbeat);
    bool Remove(int id);
    Heartbeat Get(int id);
    IEnumerable<Heartbeat> GetAll();
}
