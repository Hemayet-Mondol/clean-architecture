

using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Departments.Query;

public record GetAllDepartment:IRequest<IEnumerable<VMDepartment>>;
public class GetAllDepartmentHandler:IRequestHandler<GetAllDepartment,IEnumerable<VMDepartment>>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetAllDepartmentHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<IEnumerable<VMDepartment>> Handle(GetAllDepartment request, CancellationToken cancellationToken)
    {
        return await _departmentRepository.GetList();
    }
}
