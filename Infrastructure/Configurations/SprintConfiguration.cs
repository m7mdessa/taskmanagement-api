using Domain.Aggregates.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configurations
{
    public class SprintConfiguration : IEntityTypeConfiguration<Sprint>
    {
        public void Configure(EntityTypeBuilder<Sprint> builder)
        {
            builder
                .ToTable("Sprints");

            builder
                .HasKey(s => s.Id);

            builder
               .HasOne(sprint => sprint.Project)
               .WithMany(project => project.Sprints)
               .HasForeignKey(sprint => sprint.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
