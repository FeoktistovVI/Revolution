using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Revolution.Api.Models.Grades;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models.Grades;
using Revolution.Service.Model;

namespace Revolution.Api.Controllers;

[Route("[Controller]")]
[Produces("application/json")]

public class GradesController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IGrades _grades;

    public GradesController(IGrades grades)
    {
        _grades = grades;
    }

    [HttpPost]
    [Route($"{nameof(Add)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    /*[Authorize]*/

    public async Task<BaseResponse<long>> Add([FromBody] AddGradesRequest model)
    {
        var result = await _grades.Add(model.Id, model.SubjectId, model.StudentId, model.Grade, model.Date);
        return new BaseResponse<long>(result?.Id ?? 0);
    }

    [HttpGet]
    [Route($"{nameof(Search)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<SearchGradesResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]

    public async Task<BaseResponse<SearchGradesResponse>> Search([FromQuery] GradesGetModel model)
    {
        var result = await _grades.SearchGrades(model);
        return new BaseResponse<SearchGradesResponse>(result);
    }

    [HttpGet]
    [Route($"{nameof(Get)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<GetGradesResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    
    public async Task<BaseResponse<GetGradesResponse>> Get([FromQuery] GetGradesRequest request)
    {
        var result = await _grades.GetGradesAsync(request);
        return new BaseResponse<GetGradesResponse>(result);
    }
    
    [HttpPatch]
    [Route($"{nameof(Rename)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    /*[Authorize]*/
    public async Task<BaseResponse> Rename([FromQuery] long id, [FromQuery] long studentId, [FromQuery] long subjectId, [FromQuery] long grade, [FromQuery] string date)
    {
        await _grades.Update(id, studentId, studentId, grade, date);
        return new BaseResponse();
    }
    
    [HttpDelete]
    [Route($"{nameof(Delete)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    /*[Authorize]*/
   
    public async Task<BaseResponse> Delete([FromQuery] long id)
    {
        await _grades.Remove(id);
        return new BaseResponse();
    }
}