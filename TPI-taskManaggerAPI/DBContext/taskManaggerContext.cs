using Microsoft.EntityFrameworkCore;
using TPI_taskManaggerAPI.Entities;

namespace TPI_taskManaggerAPI.DBContext
{
    public class taskManaggerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public taskManaggerContext(DbContextOptions<taskManaggerContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator<string>("UserType")
                .HasValue<Admin>("Admin")
                .HasValue<Client>("Client");

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Password = "123",
                    Email = "roncoronit@gmail.com",
                    UserName = "Tomas",
                    UserType = "Admin"
                });

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = 3,
                    Password = "123",
                    Email = "javitonini@gmail.com",
                    UserName = "Javier",
                    UserType = "Client"
                });

            modelBuilder.Entity<Entities.Task>().HasData(
                new Entities.Task
                {
                    TaskId = 1,
                    Name = "Example Task",
                    Description = "This is an example task",
                    ClientId = 3,
                    AdminId = 1,
                });

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    CommentId = 1,
                    Content = "This is a comment on the task",
                    ClientId = 3,
                    TaskId = 1,
                });

            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Admin)
                .WithMany(a => a.CreatedTasks)
                .HasForeignKey(t => t.AdminId);

            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Client)
                .WithMany(c => c.AssginedTask)
                .HasForeignKey(t => t.ClientId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Task)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TaskId);
        }
    }
}
