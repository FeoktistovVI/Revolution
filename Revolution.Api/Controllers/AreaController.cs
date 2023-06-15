using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Revolution.Api.Models.Area;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models.Area;
using Revolution.Service.Model;

namespace Revolution.Api.Controllers;

[Route("[Controller]")]
[Produces("application/json")]

public class AreaController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IArea _area;

    public AreaController(IArea area)
    {
        _area = area;
    }

    [HttpPost]
    [Route($"{nameof(Add)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    /*[Authorize]*/

    public async Task<BaseResponse<long>> Add([FromBody] AddAreaRequest model)
    {
        var result = await _area.Add(model.Id,model.AreaName);
        return new BaseResponse<long>(result?.Id ?? 0);
    }

    [HttpGet]
    [Route($"{nameof(Search)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<SearchAreaResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]

    public async Task<BaseResponse<SearchAreaResponse>> Search([FromQuery] AreaGetModel model)
    {
        var result = await _area.SearchArea(model);
        return new BaseResponse<SearchAreaResponse>(result);
    }

    [HttpGet]
    [Route($"{nameof(Get)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<GetAreaResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    
    public async Task<BaseResponse<GetAreaResponse>> Get([FromQuery] GetAreaRequest request)
    {
        var result = await _area.GetAreaAsync(request);
        return new BaseResponse<GetAreaResponse>(result);
    }
    
    [HttpPatch]
    [Route($"{nameof(Rename)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    /*[Authorize]*/
    public async Task<BaseResponse> Rename([FromQuery] long id, [FromQuery] string areaName)
    {
        await _area.Update(id, areaName);
        return new BaseResponse();
    }
    
    [HttpDelete]
    [Route($"{nameof(Delete)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    /*[Authorize]*/
   
    public async Task<BaseResponse> Delete([FromQuery] long id)
    {
        await _area.DeleteAreaAsync(id);
        return new BaseResponse();
    }
}