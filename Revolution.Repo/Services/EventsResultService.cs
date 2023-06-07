using Microsoft.EntityFrameworkCore;
using PublishingHouse.Interfaces.Extensions.Pagination;
using Revolution.Data;
using Revolution.Repo.Enums;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models;
using Revolution.Repo.Models.EventsResult;

namespace Revolution.Repo.Services;

public class EventsResultService : IEventsResult
{
    private readonly AplicationContext _db;
    
    public EventsResultService(AplicationContext db)
    {
        _db = db;
    }
    public async Task<EventsResult> Add(long id, long studentId, string eventsresultName, long sertificateNumber, long eventId)
    {
        if (await _db.EventsResults.AllAsync(x => x.EventsResultName == eventsresultName))
            throw new TirException($"EventsResult {eventsresultName} already exists!", EnumErrorCode.EntityIsAlreadyExists);
        var eventsresult = new EventsResult
        {	Id = id,
            EventsResultName  = eventsresultName,
            StudentId = studentId,
            EventsId = eventId,
            CertificateNumber = sertificateNumber
        };
        await _db.AddAsync(eventsresult);
        await _db.SaveChangesAsync();
		
        return eventsresult;
    }

    public async Task<SearchEventsResultResponse> SearchEventsResult(EventsResultGetModel model)
    {
        return await _db.EventsResults
            .Where(x =>
                x.EventsResultName.Contains(model.Search)
                || (x.Id.ToString()).Contains(model.Search)
            ).GetPageAsync<SearchEventsResultResponse, EventsResult, EventsResultShortModel>(model, x => new EventsResultShortModel
            {
                Id =x.Id,
                EventsResultName = x.EventsResultName,
                StudentId = x.StudentId,
                EventsId = x.EventsId,
                CertificateNumber = x.CertificateNumber
            });
    }

    public async Task<GetEventsResultResponse> GetEventsResultAsync(GetEventsResultRequest request)
    {
        return await _db.EventsResults.GetPageAsync<GetEventsResultResponse, EventsResult, EventsResultShortModel>(request, eventsresult =>
            new EventsResultShortModel
            {
                Id = eventsresult.Id,
                EventsResultName = eventsresult.EventsResultName,
                StudentId = eventsresult.StudentId,
                EventsId = eventsresult.EventsId,
                CertificateNumber = eventsresult.CertificateNumber
            });
    }

    public async Task Update(long id, long studentId, string eventsresultName, long sertificateNumber, long eventId)
    {
        var eventsresult = await _db.EventsResults.FirstOrDefaultAsync(x => x.Id == id);
        if (eventsresult is null)
            throw new TirException($" Id = {id} is not found!", EnumErrorCode.EntityIsNotFound);
        if (!string.IsNullOrWhiteSpace(eventsresultName))
            eventsresult.EventsResultName = eventsresultName;
        await _db.SaveChangesAsync();
    }

    public async Task DeleteEventsResultAsync(long id)
    {
        if (await _db.EventsResults.AnyAsync(x => x.Id == id))
            throw new TirException("EventsResult is not found!", EnumErrorCode.EntityIsNotFound);

        _db.EventsResults.Remove(new EventsResult {Id = id});
        await _db.SaveChangesAsync();
    }
}