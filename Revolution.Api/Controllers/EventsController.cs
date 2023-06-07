using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Revolution.Api.Models.Events;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models.Events;
using Revolution.Service.Model;

namespace Revolution.Api.Controllers;

[Route("[Controller]")]
[Produces("application/json")]

public class EventsController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IEvents _events;

    public EventsController(IEvents events)
    {
        _events = events;
    }

    [HttpPost]
    [Route($"{nameof(Add)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    [Authorize]

    public async Task<BaseResponse<long>> Add([FromBody] AddEventsRequest model)
    {
        var result = await _events.Add(model.Id, model.EventsName, model.EventsData, model.VenueName, model.AreaId);
        return new BaseResponse<long>(result?.Id ?? 0);
    }

    [HttpGet]
    [Route($"{nameof(Search)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<SearchEventsResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]

    public async Task<BaseResponse<SearchEventsResponse>> Search([FromQuery] EventsGetModel model)
    {
        var result = await _events.SearchEvents(model);
        return new BaseResponse<SearchEventsResponse>(result);
    }

    [HttpGet]
    [Route($"{nameof(Get)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<GetEventsResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    
    public async Task<BaseResponse<GetEventsResponse>> Get([FromQuery] GetEventsRequest request)
    {
        var result = await _events.GetEventsAsync(request);
        return new BaseResponse<GetEventsResponse>(result);
    }
    
    [HttpPatch]
    [Route($"{nameof(Rename)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    [Authorize]
    public async Task<BaseResponse> Rename([FromQuery] long id, [FromQuery] string eventsName, [FromQuery] string eventsData, [FromQuery] string venueName, [FromQuery] long areaId)
    {
        await _events.Update(id, eventsName, eventsData, venueName, areaId);
        return new BaseResponse();
    }
    
    [HttpDelete]
    [Route($"{nameof(Delete)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    [Authorize]
   
    public async Task<BaseResponse> Delete([FromQuery] long id)
    {
        await _events.DeleteEventsAsync(id);
        return new BaseResponse();
    }
}