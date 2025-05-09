namespace Dating.Profile.CommandService.Infrastructure.DAO;

public class EventStorage(IDocumentSession documentSession) : IEventStorage
{
    public async Task SaveAsync(EventModel eventModel, CancellationToken ct)
    {
        documentSession.Store(eventModel);
        await documentSession.SaveChangesAsync(ct);
    }
}