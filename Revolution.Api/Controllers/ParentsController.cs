using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Revolution.Api.Models.Parents;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models.Parents;
using Revolution.Service.Model;

namespace Revolution.Api.Controllers;

[Route("[Controller]")]
[Produces("application/json")]

public class ParentsController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IParents _parents;

    public ParentsController(IParents parents)
    {
        _parents = parents;
    }

    [HttpPost]
    [Route($"{nameof(Add)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    /*[Authorize]*/

    public async Task<BaseResponse<long>> Add([FromBody] AddParentsRequest model)
    {
        var result = await _parents.Add(model.Id,model.StudentId, model.FirstName, model.LastName, model.Phone);
        return new BaseResponse<long>(result?.Id ?? 0);
    }

    [HttpGet]
    [Route($"{nameof(Search)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<SearchParentsResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]

    public async Task<BaseResponse<SearchParentsResponse>> Search([FromQuery] ParentsGetModel model)
    {
        var result = await _parents.SearchParents(model);
        return new BaseResponse<SearchParentsResponse>(result);
    }

    [HttpGet]
    [Route($"{nameof(Get)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<GetParentsResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    
    public async Task<BaseResponse<GetParentsResponse>> Get([FromQuery] GetParentsRequest request)
    {
        var result = await _parents.GetParentsAsync(request);
        return new BaseResponse<GetParentsResponse>(result);
    }
    
    [HttpPatch]
    [Route($"{nameof(Rename)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    /*[Authorize]*/
    public async Task<BaseResponse> Rename([FromQuery] long id, [FromQuery] long studentId,[FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] string phone)
    {
        await _parents.Update(id, studentId, firstName, lastName, phone);
        return new BaseResponse();
    }
    
    [HttpDelete]
    [Route($"{nameof(Delete)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    /*[Authorize]*/
   
    public async Task<BaseResponse> Delete([FromQuery] long id)
    {
        await _parents.Remove(id);
        return new BaseResponse();
    }
}