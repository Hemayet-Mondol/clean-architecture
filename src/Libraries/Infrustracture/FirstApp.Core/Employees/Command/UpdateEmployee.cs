

using AutoMapper;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Employees.Command;

public  record UpdateEmployee(int id,VMEmployee VmEmployee):IRequest<VMEmployee>;
public class updateEmployeeHandler:IRequestHandler<UpdateEmployee,VMEmployee>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public updateEmployeeHandler(IMapper mapper, IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }

    public async Task<VMEmployee> Handle(UpdateEmployee request, CancellationToken cancellationToken) => await _employeeRepository.Updated(request.id, _mapper.Map<Model.Employee>(request.VmEmployee));
    
}