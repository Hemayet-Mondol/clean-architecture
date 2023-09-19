

using AutoMapper;
using FirstApp.Infrustracture;
using FirstApp.Model;
using FirstApp.Repositories.Interface;
using FirstApp.Service.Repository.ViewModel;
using FirstApp.Shared.Common_Repository;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Repositories.Bases;

public class CityRepository : RepositoryBase<City, VMCity, int>, ICityRepository
{
    public CityRepository(IMapper mapper, FirstAppDbContext dbContext) : base(mapper, dbContext)
    {
    }
}
