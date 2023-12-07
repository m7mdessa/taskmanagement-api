using Domain.Aggregates.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configurations
{
    public class SprintTaskConfiguration : IEntityTypeConfiguration<SprintTask>
    {
        public void Configure(EntityTypeBuilder<SprintTask> builder)
        {
            builder
                .ToTable("SprintTasks");
    

            builder
                .HasKey(t => t.Id);

            builder
              .HasOne(t => t.Sprint)
              .WithMany(t => t.SprintTasks)
              .HasForeignKey(t => t.SprintId)
              .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
