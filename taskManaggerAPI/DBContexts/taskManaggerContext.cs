using Microsoft.EntityFrameworkCore;
using taskManaggerAPI.Entities;

namespace taskManaggerAPI.DBContexts
{
    public class taskManaggerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
       
        public taskManaggerContext(DbContextOptions<taskManaggerContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator<string>("UserType");

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    UserName = "Renzo",
                    Email = "renzo@gmail.com",
                    Password = "123",
                    Id = 1
                },
                new Admin
                {
                    UserName = "Tomas",
                    Email = "tomas@gmail.com",
                    Password = "123",
                    Id = 2
                });

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    UserName = "Javier",
                    Email = "javier@gmail.com",
                    Password = "123",
                    Id = 3
                },
                new Client
                {
                    UserName = "Sebastian",
                    Email = "sebastian@gmail.com",
                    Password = "123",
                    Id = 4
                });

            modelBuilder.Entity<Tasks>().HasData(
                new Tasks
                {
                    Id = 1,
                    Name = "Componente",
                    Description = "Crear componente UserList",
                    ClientId = 3,
                    AdminId = 1
                },
                new Tasks
                {
                    Id = 2,
                    Name = "Componente",
                    Description = "Crear componente DashBoard",
                    ClientId = 3,
                    AdminId = 1
                },
                new Tasks
                {
                    Id = 3,
                    Name = "Componente",
                    Description = "Crear componente Login",
                    ClientId = 3,
                    AdminId = 1
                });

            modelBuilder.Entity<Tasks>()
                .HasOne(t => t.Client)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(t => t.ClientId);

            modelBuilder.Entity<Tasks>()
                .HasOne(t => t.Admin)
                .WithMany(a => a.CreatedTasks)
                .HasForeignKey(t => t.AdminId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Task)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TaskId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
