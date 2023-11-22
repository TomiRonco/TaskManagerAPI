using Microsoft.EntityFrameworkCore;
using taskManaggerAPI.Data.Entities;

namespace taskManaggerAPI.DBContext
{
    public class taskContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public taskContext(DbContextOptions<taskContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            modelBuilder.Entity<Admin>().HasData(
               new Admin
               {
                   Id = 1,
                   Name = "Tomas",
                   Password = "123",
                   Email = "tomi@gmail.com",
                   UserName = "TomasR",
                   Role = "Admin"
               },
               new Admin
               {
                   Id = 2,
                   Name = "Renzo",
                   Password = "123",
                   Email = "renzo@gmail.com",
                   UserName = "RenzoT",
                   Role = "Admin"
               });

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = 3,
                    Name = "Javier",
                    Password = "123",
                    Email = "javitonini@gmail.com",
                    UserName = "Javier",
                    Role = "Client"
                },
                new Client
                {
                    Id = 4,
                    Name = "Javier",
                    Password = "123",
                    Email = "javitonini@gmail.com",
                    UserName = "Javier",
                    Role = "Client"
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    ProjectName = "Example Project",
                    Description = "This is an example project",
                    AdminId = 1,
                    ClientId = 2 
                });

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Content = "This is a comment on the project",
                    ClientId = 2,
                    ProjectId = 1,
                });

            // Relación entre Project y Admin
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Admin)
                .WithMany(a => a.CreatedProjects)
                .HasForeignKey(p => p.AdminId);

            // Relación entre Project y Client
            modelBuilder.Entity<Project>()
                .HasOne(c => c.Client)
                .WithMany(a => a.AssignedProjects)
                .HasForeignKey(p => p.ClientId);

            // Relación entre Comment y Project
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }

        
}
