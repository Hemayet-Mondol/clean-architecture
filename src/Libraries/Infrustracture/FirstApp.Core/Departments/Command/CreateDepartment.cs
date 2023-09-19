

using AutoMapper;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;

namespace FirstApp.Core.Departments.Command;

public record CreateDepartment(VMDepartment VmDepartment):IRequest<VMDepartment>;
public class CreateDepartmentHandler:IRequestHandler<CreateDepartment,VMDepartment>
{
    private readonly IDepartmentRepository _DepartmentRepository;
    private readonly IMapper _mapper;

    public CreateDepartmentHandler(IMapper mapper, IDepartmentRepository departmentRepository)
    {
        _mapper = mapper;
        _DepartmentRepository = departmentRepository;
    }

    public Task<VMDepartment> Handle(CreateDepartment request, CancellationToken cancellationToken) =>_DepartmentRepository.Created(_mapper.Map<Model.Department>(request.VmDepartment));
   
}
