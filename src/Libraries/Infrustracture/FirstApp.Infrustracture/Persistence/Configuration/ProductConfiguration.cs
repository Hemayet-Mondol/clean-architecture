using FirstApp.Model;
using FirstApp.Shared.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstApp.Infrustracture.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);
            builder.HasData(new
            {
                Id = 1,
                ProductName = "Walton",
                ProductDescription = "It is Bangladeshi Product",
                ProductCategory="Mobile",
                ProductPrice=25000.00,
                Created= DateTimeOffset.Now,
                CreatedBy="H",
                Stutas=EntityStutas.Created


            });
        }
    }
}
