using Microsoft.EntityFrameworkCore;
using PublishingHouse.Interfaces.Extensions.Pagination;
using Revolution.Data;
using Revolution.Repo.Enums;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models;
using Revolution.Repo.Models.Events;

namespace Revolution.Repo.Services;

public class EventsService : IEvents
{
    private readonly AplicationContext _db;
    
    public EventsService(AplicationContext db)
    {
        _db = db;
    }
    public async Task<Events> Add(long id, string eventsName, string eventsData, string venueName, long areaId)
    {
        if (await _db.Events.AllAsync(x => x.EventsName == eventsName))
            throw new TirException($"Events {eventsName} already exists!", EnumErrorCode.EntityIsAlreadyExists);
        var events = new Events
        {	Id = id,
            EventsName = eventsName,
            EventsData = eventsData,
            VenueName = venueName,
            AreaId = areaId
        };
        await _db.AddAsync(events);
        await _db.SaveChangesAsync();
		
        return events;
    }

    public async Task<SearchEventsResponse> SearchEvents(EventsGetModel model)
    {
        return await _db.Events
                    .Where(x =>
                        x.EventsName.Contains(model.Search)
                        || (x.Id.ToString()).Contains(model.Search)
                    ).GetPageAsync<SearchEventsResponse, Events, EventsShortModel>(model, x => new EventsShortModel
                    {
                        Id =x.Id,
                        EventsName = x.EventsName,
                        EventsData = x.EventsData,
                        VenueName = x.VenueName,
                        AreaId = x.AreaId
                    });
    }

    public async Task<GetEventsResponse> GetEventsAsync(GetEventsRequest request)
    {
        return await _db.Events.GetPageAsync<GetEventsResponse, Events, EventsShortModel>(request, events =>
            new EventsShortModel
            {
                Id = events.Id,
                EventsName = events.EventsName,
                EventsData = events.EventsData,
                VenueName = events.VenueName,
                AreaId = events.AreaId
            });
    }
    
    public async Task Update(long id, string eventsName, string eventsData, string venueName, long areaId)
    {
        var events = await _db.Events.FirstOrDefaultAsync(x => x.Id == id);
        if (events is null)
            throw new TirException($" Id = {id} is not found!", EnumErrorCode.EntityIsNotFound);
        if (!string.IsNullOrWhiteSpace(eventsName))
            events.EventsName = eventsName;
        await _db.SaveChangesAsync();
    }

    public async Task DeleteEventsAsync(long id)
    {
        if (await _db.Events.AnyAsync(x => x.Id == id))
            throw new TirException("Events is not found!", EnumErrorCode.EntityIsNotFound);

        _db.Events.Remove(new Events {Id = id});
        await _db.SaveChangesAsync();
    }
}