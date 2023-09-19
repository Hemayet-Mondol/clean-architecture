using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Core.Departments.Query
{
    public record GetDepartmentById(int id):IRequest<VMDepartment>;
    public class GetDepartmentByIdHandler:IRequestHandler<GetDepartmentById,VMDepartment>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetDepartmentByIdHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<VMDepartment> Handle(GetDepartmentById request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.GetById(request.id);
        }
        
    }
}
