using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Employees.Command;

public record DeleteEmployee(int id):IRequest<VMEmployee>;
public class DeleteEmployeeHandler:IRequestHandler<DeleteEmployee,VMEmployee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<VMEmployee> Handle(DeleteEmployee request, CancellationToken cancellationToken) => await _employeeRepository.Delete(request.id);
}
