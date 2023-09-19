using FirstApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstApp.Infrustracture.Persistence.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        
        builder.ToTable("Employee");
        
        
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Country)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.CounrtyId).IsRequired();

        builder.HasOne(x => x.State)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.StateId)
            .IsRequired();

        builder.HasOne(x => x.City)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.CityId)
            .IsRequired();

        builder.HasOne(x => x.Department)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.DepartmentId)
            .IsRequired();

    }
}
