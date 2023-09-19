using FirstApp.Core.Departments.Command;
using FirstApp.Core.Departments.Query;
using FirstApp.Service.Repository.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IMediator _mediator;
    public DepartmentController(IMediator mediator)=> _mediator = mediator;
    [HttpGet]
    public async Task<ActionResult<VMDepartment>> Get() => Ok(await _mediator.Send(new GetAllDepartment()));
    [HttpGet("id")]
    public async Task<ActionResult<VMDepartment>>Get(int id)=>Ok(await _mediator.Send(new GetDepartmentById(id)));
    [HttpPost]
    public async Task<ActionResult<VMDepartment>> PostAsync([FromBody] VMDepartment Vmdepartment) => Ok(await _mediator.Send(new CreateDepartment(Vmdepartment)));
    [HttpPut("id")]
    public async Task<ActionResult<VMDepartment>>PutAsync(int id, [FromBody] VMDepartment Vmdepartment)=>Ok(await _mediator.Send(new UpdateDepartment(id,Vmdepartment)));
    [HttpDelete("id")]
    public async Task<ActionResult<VMDepartment>> DeleteAsync(int id) => Ok(await _mediator.Send(new DeleteDepartment(id)));
}
