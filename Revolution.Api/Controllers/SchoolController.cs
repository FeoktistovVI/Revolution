using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Revolution.Api.Models.School;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models.School;
using Revolution.Service.Model;

namespace Revolution.Api.Controllers;

[Route("[Controller]")]
[Produces("application/json")]

public class SchoolController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ISchool _school;

    public SchoolController(ISchool school)
    {
        _school = school;
    }

    [HttpPost]
    [Route($"{nameof(Add)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    /*[Authorize]*/

    public async Task<BaseResponse<long>> Add([FromBody] AddSchoolRequest model)
    {
        var result = await _school.Add(model.Id,model.Name,model.AreaId);
        return new BaseResponse<long>(result?.Id ?? 0);
    }

    [HttpGet]
    [Route($"{nameof(Search)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<SearchSchoolResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]

    public async Task<BaseResponse<SearchSchoolResponse>> Search([FromQuery] SchoolGetModel model)
    {
        var result = await _school.SearchSchool(model);
        return new BaseResponse<SearchSchoolResponse>(result);
    }

    [HttpGet]
    [Route($"{nameof(Get)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<GetSchoolResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    
    public async Task<BaseResponse<GetSchoolResponse>> Get([FromQuery] GetSchoolRequest request)
    {
        var result = await _school.GetSchoolAsync(request);
        return new BaseResponse<GetSchoolResponse>(result);
    }
    
    [HttpPatch]
    [Route($"{nameof(Rename)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    /*[Authorize]*/
    public async Task<BaseResponse> Rename([FromQuery] long id, [FromQuery] string name, [FromQuery] long areaId)
    {
        await _school.Update(id, name, areaId);
        return new BaseResponse();
    }
    
    [HttpDelete]
    [Route($"{nameof(Delete)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    /*[Authorize]*/
   
    public async Task<BaseResponse> Delete([FromQuery] long id)
    {
        await _school.DeleteSchoolAsync(id);
        return new BaseResponse();
    }
}