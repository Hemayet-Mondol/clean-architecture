

using AutoMapper;
using FirstApp.Infrustracture;
using FirstApp.Model;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using FirstApp.Shared.Common_Repository;


namespace FirstApp.Repositories.Bases;

public class EmployeeRepository : RepositoryBase<Employee, VMEmployee, int>, IEmployeeRepository
{
    public EmployeeRepository(IMapper mapper, FirstAppDbContext dbContext) : base(mapper, dbContext)
    {
    }
}
