using FirstApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstApp.Infrustracture.Persistence.Configuration;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("City");
        builder.HasKey(x => x.Id);
        builder.HasOne(x=>x.State)
            .WithMany(x=>x.Citys)
            .HasForeignKey(x=>x.StateId)
            .IsRequired(true);
    }
}
