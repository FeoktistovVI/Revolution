using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Revolution.Api.Models.EventsResult;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models.EventsResult;
using Revolution.Service.Model;

namespace Revolution.Api.Controllers;

[Route("[Controller]")]
[Produces("application/json")]

public class EventsResultController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IEventsResult _eventsResult;

    public EventsResultController(IEventsResult eventsResult)
    {
        _eventsResult = eventsResult;
    }

    [HttpPost]
    [Route($"{nameof(Add)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    [Authorize]

    public async Task<BaseResponse<long>> Add([FromBody] AddEventsResultRequest model)
    {
        var result = await _eventsResult.Add(model.Id, model.StudentId, model.EventsResultName, model.CertificateNumber, model.EventsId);
        return new BaseResponse<long>(result?.Id ?? 0);
    }

    [HttpGet]
    [Route($"{nameof(Search)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<SearchEventsResultResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]

    public async Task<BaseResponse<SearchEventsResultResponse>> Search([FromQuery] EventsResultGetModel model)
    {
        var result = await _eventsResult.SearchEventsResult(model);
        return new BaseResponse<SearchEventsResultResponse>(result);
    }

    [HttpGet]
    [Route($"{nameof(Get)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<GetEventsResultResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    
    public async Task<BaseResponse<GetEventsResultResponse>> Get([FromQuery] GetEventsResultRequest request)
    {
        var result = await _eventsResult.GetEventsResultAsync(request);
        return new BaseResponse<GetEventsResultResponse>(result);
    }
    
    [HttpPatch]
    [Route($"{nameof(Rename)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    [Authorize]
    public async Task<BaseResponse> Rename([FromQuery] long id, [FromQuery] long studentId, [FromQuery] string eventsresultName, [FromQuery] long eventsId, [FromQuery] long certificateNumber)
    {
        await _eventsResult.Update(id, studentId, eventsresultName, certificateNumber, eventsId);
        return new BaseResponse();
    }
    
    [HttpDelete]
    [Route($"{nameof(Delete)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    [Authorize]
   
    public async Task<BaseResponse> Delete([FromQuery] long id)
    {
        await _eventsResult.DeleteEventsResultAsync(id);
        return new BaseResponse();
    }
}