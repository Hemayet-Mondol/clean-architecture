

using AutoMapper;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Employees.Command;

public record CreateEmployee(VMEmployee VmEmployee):IRequest<VMEmployee>;
public class CreateEmployeHandler:IRequestHandler<CreateEmployee,VMEmployee>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public CreateEmployeHandler(IMapper mapper, IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }

    public async Task<VMEmployee> Handle(CreateEmployee request, CancellationToken cancellationToken) => await _employeeRepository.Created( _mapper.Map<Model.Employee>(request.VmEmployee));
    
}
