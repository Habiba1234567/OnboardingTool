﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnboardingTool.Data;

#nullable disable

namespace OnboardingTool.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230805230024_initial migration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoursesUser_courses", b =>
                {
                    b.Property<Guid>("coursesCourse_code")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("user_coursesCourse_code")
                        .HasColumnType("int");

                    b.HasKey("coursesCourse_code", "user_coursesCourse_code");

                    b.HasIndex("user_coursesCourse_code");

                    b.ToTable("CoursesUser_courses");
                });

            modelBuilder.Entity("OnboardingTool.Models.Domain.Courses", b =>
                {
                    b.Property<Guid>("Course_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Course_code");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("OnboardingTool.Models.Domain.Roles", b =>
                {
                    b.Property<int>("type_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("type_code"));

                    b.Property<bool>("is_buddy")
                        .HasColumnType("bit");

                    b.Property<bool>("new_employee")
                        .HasColumnType("bit");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("type_code");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("OnboardingTool.Models.Domain.User_courses", b =>
                {
                    b.Property<int>("Course_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Course_code"));

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Course_code");

                    b.HasIndex("UsersId");

                    b.ToTable("User_Courses");
                });

            modelBuilder.Entity("OnboardingTool.Models.Domain.User_roles", b =>
                {
                    b.Property<int>("type_code")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("type_code", "user_id");

                    b.HasIndex("UsersId");

                    b.ToTable("User_roles");
                });

            modelBuilder.Entity("OnboardingTool.Models.Domain.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role_id")
                        .HasColumnType("int");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("enrollment_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("job_title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phoneNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OnboardingTool.Models.Domain.log", b =>
                {
                    b.Property<DateTime>("time_of_occurance")
                        .HasColumnType("datetime2");

                    b.Property<string>("action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("actor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("time_of_occurance");

                    b.ToTable("logs");
                });

            modelBuilder.Entity("Userslog", b =>
                {
                    b.Property<DateTime>("logstime_of_occurance")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("usersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("logstime_of_occurance", "usersId");

                    b.HasIndex("usersId");

                    b.ToTable("Userslog");
                });

            modelBuilder.Entity("CoursesUser_courses", b =>
                {
                    b.HasOne("OnboardingTool.Models.Domain.Courses", null)
                        .WithMany()
                        .HasForeignKey("coursesCourse_code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnboardingTool.Models.Domain.User_courses", null)
                        .WithMany()
                        .HasForeignKey("user_coursesCourse_code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnboardingTool.Models.Domain.User_courses", b =>
                {
                    b.HasOne("OnboardingTool.Models.Domain.Users", "Users")
                        .WithMany("course")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("OnboardingTool.Models.Domain.User_roles", b =>
                {
                    b.HasOne("OnboardingTool.Models.Domain.Users", "Users")
                        .WithMany("roles")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnboardingTool.Models.Domain.Roles", "Roles")
                        .WithMany("user_roles")
                        .HasForeignKey("type_code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Userslog", b =>
                {
                    b.HasOne("OnboardingTool.Models.Domain.log", null)
                        .WithMany()
                        .HasForeignKey("logstime_of_occurance")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnboardingTool.Models.Domain.Users", null)
                        .WithMany()
                        .HasForeignKey("usersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnboardingTool.Models.Domain.Roles", b =>
                {
                    b.Navigation("user_roles");
                });

            modelBuilder.Entity("OnboardingTool.Models.Domain.Users", b =>
                {
                    b.Navigation("course");

                    b.Navigation("roles");
                });
#pragma warning restore 612, 618
        }
    }
}