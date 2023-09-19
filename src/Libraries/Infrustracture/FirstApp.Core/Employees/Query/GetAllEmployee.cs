

using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Employees.Query;

public  record GetAllEmployee:IRequest<IEnumerable<VMEmployee>>;
public class GetAllEmployeeHandler:IRequestHandler<GetAllEmployee,IEnumerable<VMEmployee>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetAllEmployeeHandler(IEmployeeRepository employeeRepository) =>_employeeRepository = employeeRepository;

     

    public async Task<IEnumerable<VMEmployee>> Handle(GetAllEmployee request, CancellationToken cancellationToken) => await _employeeRepository.GetAllAsync(c=>  c.Country,d=>d.City, e=>e.State,e=>e.Department);

}
