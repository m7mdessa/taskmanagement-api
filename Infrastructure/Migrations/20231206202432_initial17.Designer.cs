﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(TaskManagementContext))]
    [Migration("20231206202432_initial17")]
    partial class initial17
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("TaskManagement")
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Aggregates.DeveloperAggregate.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Developers", "TaskManagement");
                });

            modelBuilder.Entity("Domain.Aggregates.DeveloperAggregate.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles", "TaskManagement");
                });

            modelBuilder.Entity("Domain.Aggregates.ProjectAggregate.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("ProjectName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Projects", "TaskManagement");
                });

            modelBuilder.Entity("Domain.Aggregates.ProjectAggregate.Sprint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<string>("SprintName")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Sprints", "TaskManagement");
                });

            modelBuilder.Entity("Domain.Aggregates.ProjectAggregate.SprintTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DeveloperId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("SprintId")
                        .HasColumnType("integer");

                    b.Property<string>("TaskDescription")
                        .HasColumnType("text");

                    b.Property<DateTime>("TaskDuration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TaskName")
                        .HasColumnType("text");

                    b.Property<string>("TaskStatus")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SprintId");

                    b.ToTable("SprintTasks", "TaskManagement");
                });

            modelBuilder.Entity("Domain.Aggregates.DeveloperAggregate.Developer", b =>
                {
                    b.HasOne("Domain.Aggregates.DeveloperAggregate.Role", "Role")
                        .WithMany("Developer")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.Aggregates.DeveloperAggregate.Address", "Address", b1 =>
                        {
                            b1.Property<int>("DeveloperId")
                                .HasColumnType("integer");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("DeveloperId");

                            b1.ToTable("Developers", "TaskManagement");

                            b1.WithOwner()
                                .HasForeignKey("DeveloperId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Aggregates.ProjectAggregate.Sprint", b =>
                {
                    b.HasOne("Domain.Aggregates.ProjectAggregate.Project", "Project")
                        .WithMany("Sprints")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Domain.Aggregates.ProjectAggregate.SprintTask", b =>
                {
                    b.HasOne("Domain.Aggregates.ProjectAggregate.Sprint", "Sprint")
                        .WithMany("SprintTasks")
                        .HasForeignKey("SprintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sprint");
                });

            modelBuilder.Entity("Domain.Aggregates.DeveloperAggregate.Role", b =>
                {
                    b.Navigation("Developer");
                });

            modelBuilder.Entity("Domain.Aggregates.ProjectAggregate.Project", b =>
                {
                    b.Navigation("Sprints");
                });

            modelBuilder.Entity("Domain.Aggregates.ProjectAggregate.Sprint", b =>
                {
                    b.Navigation("SprintTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
