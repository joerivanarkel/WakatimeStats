using Common.Exceptions;
using Common.Models;
using DataAccess;

namespace joerivanarkel.Wakatime;

public class HeartbeatRepository
{
    public DatabaseContext Database;

    public HeartbeatRepository(DatabaseContext databaseContext)
    {
        Database = databaseContext;
    }

    public bool Add(Heartbeat heartbeat)
    {
        Database.Heartbeats.Add(heartbeat);
        return Database.SaveChanges() > 0;
    }

    public bool AddRange(IEnumerable<Heartbeat> heartbeats)
    {
        Database.Heartbeats.AddRange(heartbeats);
        return Database.SaveChanges() > 0;
    }

    public bool Update(Heartbeat heartbeat)
    {
        Database.Heartbeats.Update(heartbeat);
        return Database.SaveChanges() > 0;
    }

    public bool Remove(int id)
    {
        Database.Heartbeats.Remove(Database.Heartbeats.Find(id) ?? throw new RepositoryException("Heartbeat not found"));
        return Database.SaveChanges() > 0;
    }

    public Heartbeat Get(int id)
    {
        return Database.Heartbeats.Find(id) ?? throw new RepositoryException("Heartbeat not found");
    }

    public IEnumerable<Heartbeat> GetAll()
    {
        return Database.Heartbeats.ToList();
    }
}
