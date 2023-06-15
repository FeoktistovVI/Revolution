using Revolution.Data.Models;
using Revolution.Repo.Models.EventsResult;

namespace Revolution.Repo.Interfaces;

public interface IEventsResult
{
    Task<EventsResult> Add(long id,long studentId, string eventsresultName , long sertificateNumber, long eventId);

    Task<SearchEventsResultResponse> SearchEventsResult(EventsResultGetModel model);

    Task<GetEventsResultResponse> GetEventsResultAsync(GetEventsResultRequest request);
    
    Task Update(long id,long studentId, string eventsresultName , long sertificateNumber, long eventId);
    
    Task DeleteEventsResultAsync(long id);
}