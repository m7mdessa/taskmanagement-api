using Domain.Aggregates.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Configurations;
using Domain.Aggregates.DeveloperAggregate;


namespace Infrastructure
{
    public partial class TaskManagementContext : DbContext
    {
        public TaskManagementContext()
        {
        }

        public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        
        public DbSet<Developer> Developers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=test;Username=postgres;Password=mohammad1999;Include Error Detail=true");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.HasDefaultSchema("TaskManagement");
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new SprintConfiguration());
            modelBuilder.ApplyConfiguration(new SprintTaskConfiguration());
            modelBuilder.ApplyConfiguration(new DeveloperConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginConfiguration());


        }

    }

}

