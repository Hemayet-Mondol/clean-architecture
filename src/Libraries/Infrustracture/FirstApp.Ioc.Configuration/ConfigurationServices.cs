using FirstApp.Core;
using FirstApp.Core.Mapper;
using FirstApp.Infrustracture;
using FirstApp.Repositories.Bases;
using FirstApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FirstApp.Ioc.Configuration;

public static class ConfigurationServices
{
    public static IServiceCollection AddExtention(this IServiceCollection services, IConfiguration configuration) {

        services.AddDbContext<FirstAppDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("MyConnection")));
        services.AddAutoMapper(typeof(CommonMapper).Assembly);
        services.AddTransient<IProductRepository,ProductRepository >();
        services.AddTransient<IEmployeeRepository,EmployeeRepository >();
        services.AddTransient<ICountryRepository,CountryRepository >();
        services.AddTransient<IStateRepository,StateRepository >();
        services.AddTransient<ICityRepository,CityRepository >();
        services.AddTransient<IDepartmentRepository,DepartmentRepository >();
        services.AddMediatR(options=>options.RegisterServicesFromAssemblies(typeof(ICore).Assembly));
        return services;
        

    }
}
