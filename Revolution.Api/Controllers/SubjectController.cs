using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Revolution.Api.Models.Subject;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models.Subject;
using Revolution.Service.Model;
namespace Revolution.Api.Controllers;

[Route("[Controller]")]
[Produces("application/json")]

public class SubjectController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ISubject _subject;

    public SubjectController(ISubject subject)
    {
        _subject = subject;
    }

    [HttpPost]
    [Route($"{nameof(Add)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    /*[Authorize]*/

    public async Task<BaseResponse<long>> Add([FromBody] AddSubjectRequest model)
    {
        var result = await _subject.Add(model.Id,model.Name);
        return new BaseResponse<long>(result?.Id ?? 0);
    }

    [HttpGet]
    [Route($"{nameof(Search)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<SearchSubjectResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]

    public async Task<BaseResponse<SearchSubjectResponse>> Search([FromQuery] SubjectGetModel model)
    {
        var result = await _subject.SearchSubject(model);
        return new BaseResponse<SearchSubjectResponse>(result);
    }

    [HttpGet]
    [Route($"{nameof(Get)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<GetSubjectResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    
    public async Task<BaseResponse<GetSubjectResponse>> Get([FromQuery] GetSubjectRequest request)
    {
        var result = await _subject.GetSubjectAsync(request);
        return new BaseResponse<GetSubjectResponse>(result);
    }
    
    [HttpPatch]
    [Route($"{nameof(Rename)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    /*[Authorize]*/
    public async Task<BaseResponse> Rename([FromQuery] long id, [FromQuery] string name)
    {
        await _subject.Update(id, name);
        return new BaseResponse();
    }
    
    [HttpDelete]
    [Route($"{nameof(Delete)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    /*[Authorize]*/   
    public async Task<BaseResponse> Delete([FromQuery] long id)
    {
        await _subject.DeleteSubjectAsync(id);
        return new BaseResponse();
    }
}