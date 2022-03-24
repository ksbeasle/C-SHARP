﻿// <auto-generated />
using System;
using GraphQLDemo.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraphQLDemo.API.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20220324033748_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("CourseDTOStudentDTO", b =>
                {
                    b.Property<Guid>("CoursesId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("TEXT");

                    b.HasKey("CoursesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseDTOStudentDTO");
                });

            modelBuilder.Entity("GraphQLDemo.API.DTOs.CourseDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Sub")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("instructorId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("instructorId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("GraphQLDemo.API.DTOs.InstructorDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("salary")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("GraphQLDemo.API.DTOs.StudentDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("InstructorDTOId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InstructorDTOId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CourseDTOStudentDTO", b =>
                {
                    b.HasOne("GraphQLDemo.API.DTOs.CourseDTO", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GraphQLDemo.API.DTOs.StudentDTO", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GraphQLDemo.API.DTOs.CourseDTO", b =>
                {
                    b.HasOne("GraphQLDemo.API.DTOs.InstructorDTO", "Instructor")
                        .WithMany()
                        .HasForeignKey("instructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("GraphQLDemo.API.DTOs.StudentDTO", b =>
                {
                    b.HasOne("GraphQLDemo.API.DTOs.InstructorDTO", null)
                        .WithMany("Students")
                        .HasForeignKey("InstructorDTOId");
                });

            modelBuilder.Entity("GraphQLDemo.API.DTOs.InstructorDTO", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
