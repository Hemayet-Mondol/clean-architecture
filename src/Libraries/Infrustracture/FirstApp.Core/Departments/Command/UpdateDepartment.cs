

using AutoMapper;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Departments.Command;

public  record UpdateDepartment(int id,VMDepartment VmDepartment):IRequest<VMDepartment>;
public class UpdateDepartmentHandler:IRequestHandler<UpdateDepartment,VMDepartment>
{
    private readonly IDepartmentRepository _DepartmentRepository;
    private readonly IMapper _mapper;

    public UpdateDepartmentHandler(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _DepartmentRepository = departmentRepository;
        _mapper = mapper;
    }

    public async Task<VMDepartment> Handle(UpdateDepartment request, CancellationToken cancellationToken)
    => await _DepartmentRepository.Updated(request.id, _mapper.Map<Model.Department>(request.VmDepartment));
    
}
