

using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Departments.Command;

public  record DeleteDepartment(int id):IRequest<VMDepartment>;
public class DeleteDepartmentHandler:IRequestHandler<DeleteDepartment,VMDepartment>
{
    private readonly IDepartmentRepository _departmentRepository;
    public DeleteDepartmentHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<VMDepartment> Handle(DeleteDepartment request, CancellationToken cancellationToken)=> await _departmentRepository.Delete(request.id);
}
