

using FirstApp.Model;
using FirstApp.Service.Repository.ViewModel;
using FirstApp.Shared.Common_Repository;

namespace FirstApp.Repositories.Interface;

public interface ICityRepository:IRepository<City,VMCity,int>
{
}
