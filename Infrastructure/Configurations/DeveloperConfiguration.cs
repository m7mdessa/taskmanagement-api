using Domain.Aggregates.DeveloperAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
    {

        public void Configure(EntityTypeBuilder<Developer> builder)
        {


            builder
                .ToTable("Developers");

            builder
                .OwnsOne(d => d.Address);
            builder
                .HasKey(d => d.Id);

         

        }
    }
}
