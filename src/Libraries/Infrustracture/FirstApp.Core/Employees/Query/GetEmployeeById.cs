

using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Employees.Query;

public record GetEmployeeById(int id):IRequest<VMEmployee>;
public class GetEmployeeByIdHandler:IRequestHandler<GetEmployeeById,VMEmployee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeByIdHandler(IEmployeeRepository employeeRepository)=>
        _employeeRepository = employeeRepository;

    public async Task<VMEmployee> Handle(GetEmployeeById request, CancellationToken cancellationToken) => await _employeeRepository.GetById(request.id);
    
        
    
}
