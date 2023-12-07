using Domain.Aggregates.ProjectAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Aggregates.DeveloperAggregate;

namespace Infrastructure.Configurations
{
    internal class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder
                .ToTable("UserLogins");

            builder
                .HasKey(s => s.Id);

            builder
               .HasOne(d => d.Developer)
               .WithMany(u => u.UserLogins)
               .HasForeignKey(d => d.DeveloperId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
           .HasOne(r => r.Role)
           .WithMany(u => u.UserLogins)
           .HasForeignKey(r => r.RoleId)
           .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
