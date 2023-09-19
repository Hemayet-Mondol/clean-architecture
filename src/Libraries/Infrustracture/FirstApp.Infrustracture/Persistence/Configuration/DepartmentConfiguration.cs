using FirstApp.Model;
using FirstApp.Shared.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstApp.Infrustracture.Persistence.Configuration;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Department");
        builder.HasKey(x => x.Id);
        builder.HasData(new
        {
            Id = 1,
            DepartmentName = "IT",
            Created = DateTimeOffset.Now,
            CreatedBy = "HHH",
            Stutas = EntityStutas.Created
        });
        
    }
}
