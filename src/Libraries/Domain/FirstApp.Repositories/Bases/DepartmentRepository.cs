
using AutoMapper;
using FirstApp.Infrustracture;
using FirstApp.Model;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using FirstApp.Shared.Common_Repository;

namespace FirstApp.Repositories.Bases;

public class DepartmentRepository : RepositoryBase<Department, VMDepartment, int>, IDepartmentRepository
{
    public DepartmentRepository(IMapper mapper, FirstAppDbContext dbContext) : base(mapper, dbContext)
    {
    }
}
