using Revolution.Data.Models;
using Revolution.Repo.Models.Events;

namespace Revolution.Repo.Interfaces;

public interface IEvents
{
    Task<Events> Add(long id, string eventsName, string eventsData, string venueName, long areaId);

    Task<SearchEventsResponse> SearchEvents(EventsGetModel model);

   
    Task<GetEventsResponse> GetEventsAsync(GetEventsRequest request);
    
    Task Update(long id, string eventsName, string eventsData, string venueName, long areaId);
    
    Task DeleteEventsAsync(long id);
}