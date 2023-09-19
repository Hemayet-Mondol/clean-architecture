using FirstApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstApp.Infrustracture.Persistence.Configuration;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("State");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Country)
            .WithMany(x => x.State)
            .HasForeignKey(x => x.CountryId).IsRequired(true);
    }
}
