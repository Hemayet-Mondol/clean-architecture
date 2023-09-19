using FirstApp.Shared.Common;
using System.Linq.Expressions;

namespace FirstApp.Shared.Common_Repository;

public interface IRepository< TEntity,IModel,T>
    where TEntity : class,IEntity<T>,new()
    where IModel : class,IVM
    where T:IEquatable<T>
{
    public Task<IModel> GetById(T id);
    public Task<List<IModel>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
    public Task<IEnumerable<IModel>> GetList();
    public Task<IModel> Created(TEntity entity);
    public Task<IModel> Updated(T id, TEntity entity);
    public Task <IModel>  Delete(T id);
    
}
