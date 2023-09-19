using AutoMapper;
using FirstApp.Shared.Common;
using FirstApp.Shared.Extentions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FirstApp.Shared.Common_Repository;

public abstract class RepositoryBase <TEntity,IModel,T>:IRepository<TEntity,IModel,T>
    where TEntity : class,IEntity<T>,new()
    where IModel :class,IVM
    where T: IEquatable<T>

{
    private readonly IMapper _mapper;
    private readonly DbContext _dbContext;
    protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

    public RepositoryBase(IMapper mapper, DbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    public async Task<List<IModel>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        var entities = await includes.Aggregate(
            _dbContext.Set<TEntity>().AsQueryable(), (current, include) => current.Include(include))
            .ToListAsync().ConfigureAwait(true);

        return _mapper.Map<List<IModel>>(entities);
    }
    public async Task<IModel> GetById(T id)
    {
        var data= await DbSet.FindAsync(id);
        return _mapper.Map<IModel>(data);
    }

    public  Task<IEnumerable<IModel>> GetList()
    {

        var data = DbSet.AsEnumerable();
        var models = _mapper.Map < IEnumerable <IModel>>(data);

        return Task.FromResult(models);


    }

    public async Task<IModel> Created(TEntity entity)
    {
        DbSet.Add(entity);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<IModel>(entity);

    }

    public async Task<IModel> Updated(T id, TEntity entity)
    {
        var temp = await DbSet.FindAsync(id);
        if(temp is not null)
        {
            entity.Copy(temp);
            DbSet.Entry(temp).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<IModel>(entity);

        }
        throw new ArgumentNullException();
    }

    public async Task<IModel> Delete(T id)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity == null)
        {
            throw new InvalidOperationException("Data not found");
        }
        DbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<IModel>(entity);



    }
}
