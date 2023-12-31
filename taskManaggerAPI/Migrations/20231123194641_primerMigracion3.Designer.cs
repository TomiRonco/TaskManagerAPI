﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using taskManaggerAPI.DBContext;

#nullable disable

namespace taskManaggerAPI.Migrations
{
    [DbContext(typeof(taskContext))]
    [Migration("20231123194641_primerMigracion3")]
    partial class primerMigracion3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("taskManaggerAPI.Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 2,
                            Content = "This is a comment on the project",
                            ProjectId = 1
                        });
                });

            modelBuilder.Entity("taskManaggerAPI.Data.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdminId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("ClientId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdminId = 1,
                            ClientId = 2,
                            Description = "This is an example project",
                            ProjectName = "Example Project",
                            State = true
                        });
                });

            modelBuilder.Entity("taskManaggerAPI.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("taskManaggerAPI.Data.Entities.Admin", b =>
                {
                    b.HasBaseType("taskManaggerAPI.Data.Entities.User");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("Users", t =>
                        {
                            t.Property("Role")
                                .HasColumnName("Admin_Role");
                        });

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "tomi@gmail.com",
                            Name = "Tomas",
                            Password = "123",
                            State = true,
                            UserName = "TomasR",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "renzo@gmail.com",
                            Name = "Renzo",
                            Password = "123",
                            State = true,
                            UserName = "RenzoT",
                            Role = "Admin"
                        });
                });

            modelBuilder.Entity("taskManaggerAPI.Data.Entities.Client", b =>
                {
                    b.HasBaseType("taskManaggerAPI.Data.Entities.User");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Client");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Email = "javitonini@gmail.com",
                            Name = "Javier",
                            Password = "123",
                            State = true,
                            UserName = "Javier",
                            Role = "Client"
                        },
                        new
                        {
                            Id = 4,
                            Email = "javitonini@gmail.com",
                            Name = "Javier",
                            Password = "123",
                            State = true,
                            UserName = "Javier",
                            Role = "Client"
                        });
                });

            modelBuilder.Entity("taskManaggerAPI.Data.Entities.Comment", b =>
                {
                    b.HasOne("taskManaggerAPI.Data.Entities.Client", "Client")
                        .WithMany("Comments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("taskManaggerAPI.Data.Entities.Project", "Project")
                        .WithMany("Comments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("taskManaggerAPI.Data.Entities.Project", b =>
                {
                    b.HasOne("taskManaggerAPI.Data.Entities.Admin", "Admin")
                        .WithMany("CreatedProjects")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("taskManaggerAPI.Data.Entities.Client", "Client")
                        .WithMany("AssignedProjects")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("taskManaggerAPI.Data.Entities.Project", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("taskManaggerAPI.Data.Entities.Admin", b =>
                {
                    b.Navigation("CreatedProjects");
                });

            modelBuilder.Entity("taskManaggerAPI.Data.Entities.Client", b =>
                {
                    b.Navigation("AssignedProjects");

                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
