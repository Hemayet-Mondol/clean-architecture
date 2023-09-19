

using AutoMapper;
using FirstApp.Infrustracture;
using FirstApp.Model;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using FirstApp.Shared.Common_Repository;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Repositories.Bases;

public class StateRepository : RepositoryBase<State, VMState, int>, IStateRepository
{
    public StateRepository(IMapper mapper, FirstAppDbContext dbContext) : base(mapper, dbContext)
    {
    }
}
