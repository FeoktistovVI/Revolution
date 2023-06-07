using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Revolution.Api.Models.Student;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models.Student;
using Revolution.Service.Model;

namespace Revolution.Api.Controllers;

[Route("[Controller]")]
[Produces("application/json")]

public class StudentController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IStudent _student;

    public StudentController(IStudent student)
    {
        _student = student;
    }

    [HttpPost]
    [Route($"{nameof(Add)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    [Authorize]

    public async Task<BaseResponse<long>> Add([FromBody] AddStudentRequest model)
    {
        var result = await _student.Add(model.Id,model.FirstName, model.LastName, model.DateOfBirth,model.FatherName,model.Grade,model.SchoolId);
        return new BaseResponse<long>(result?.Id ?? 0);
    }

    [HttpGet]
    [Route($"{nameof(Search)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<SearchStudentResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]

    public async Task<BaseResponse<SearchStudentResponse>> Search([FromQuery] StudentGetModel model)
    {
        var result = await _student.SearchStudents(model);
        return new BaseResponse<SearchStudentResponse>(result);
    }

    [HttpGet]
    [Route($"{nameof(Get)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<GetStudentResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    
    public async Task<BaseResponse<GetStudentResponse>> Get([FromQuery] GetStudentRequest request)
    {
        var result = await _student.GetStudentAsync(request);
        return new BaseResponse<GetStudentResponse>(result);
    }
    
    [HttpPatch]
    [Route($"{nameof(Rename)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    [Authorize]
    public async Task<BaseResponse> Rename([FromQuery] long id, [FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] string fatherName, [FromQuery] string dateOfBirth,[FromQuery] long grade, [FromQuery] long schoolId)
    {
        await _student.Update(id, firstName, lastName, dateOfBirth, fatherName, grade, schoolId);
        return new BaseResponse();
    }
    
    [HttpDelete]
    [Route($"{nameof(Delete)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    [Authorize]
   
    public async Task<BaseResponse> Delete([FromQuery] long id)
    {
        await _student.Remove(id);
        return new BaseResponse();
    }
}