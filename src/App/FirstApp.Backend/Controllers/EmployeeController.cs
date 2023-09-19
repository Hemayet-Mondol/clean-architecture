using FirstApp.Core.Cities.Command;
using FirstApp.Core.Cities.Query;
using FirstApp.Core.Employees.Command;
using FirstApp.Core.Employees.Query;
using FirstApp.Service.Repository.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;
    public EmployeeController(IMediator mediator) => _mediator = mediator;
    [HttpGet]
    public async Task<ActionResult<VMEmployee>> Get() => Ok(await _mediator.Send(new GetAllEmployee()));
    [HttpGet("{id:int}")]
    public async Task<ActionResult<VMEmployee>> Get(int id) => Ok(await _mediator.Send(new GetEmployeeById(id)));
    [HttpPost]
    public async Task<ActionResult<VMEmployee>> PostAsync([FromBody] VMEmployee vMEmployee) => Ok(await _mediator.Send(new CreateEmployee(vMEmployee)));
    [HttpPut("{id:int}")]
    public async Task<ActionResult<VMEmployee>> PutAsync(int id, [FromBody] VMEmployee vMEmployee) => Ok(await _mediator.Send(new UpdateEmployee(id, vMEmployee)));
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<VMEmployee>> DeleteAsync(int id) => Ok(await _mediator.Send(new DeleteEmployee(id)));
}
