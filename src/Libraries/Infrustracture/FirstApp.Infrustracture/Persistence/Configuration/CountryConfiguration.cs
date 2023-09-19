using FirstApp.Model;
using FirstApp.Shared.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FirstApp.Infrustracture.Persistence.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
            builder.HasKey(x => x.Id);
            builder.HasData(new
            {
                Id = 1,
                CountryName ="Bangladesh",
                Created = DateTimeOffset.Now,
                CreatedBy = "HHH",
                Stutas= EntityStutas.Created

            },
            new
            {
                Id=2,
                CountryName="India",
                Created=DateTimeOffset.Now,
                CreatedBy="lkjhg",
                Stutas=EntityStutas.Created

            });
        }
    }
}
