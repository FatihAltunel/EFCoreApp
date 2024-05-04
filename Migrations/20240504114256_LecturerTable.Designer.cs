﻿// <auto-generated />
using System;
using EFCoreApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240504114256_LecturerTable")]
    partial class LecturerTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("EFCoreApp.Data.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("LecturerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CourseId");

                    b.HasIndex("LecturerId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EFCoreApp.Data.CourseRegister", b =>
                {
                    b.Property<int>("CourseRegisterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RegsiterDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CourseRegisterId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseRegisters");
                });

            modelBuilder.Entity("EFCoreApp.Data.Lecturer", b =>
                {
                    b.Property<int>("LecturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LecturerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LecturerId");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("EFCoreApp.Data.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EFCoreApp.Data.Course", b =>
                {
                    b.HasOne("EFCoreApp.Data.Lecturer", "lecturer")
                        .WithMany("Courses")
                        .HasForeignKey("LecturerId");

                    b.Navigation("lecturer");
                });

            modelBuilder.Entity("EFCoreApp.Data.CourseRegister", b =>
                {
                    b.HasOne("EFCoreApp.Data.Course", "course")
                        .WithMany("CourseRegisters")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreApp.Data.Student", "student")
                        .WithMany("CourseRegisters")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("student");
                });

            modelBuilder.Entity("EFCoreApp.Data.Course", b =>
                {
                    b.Navigation("CourseRegisters");
                });

            modelBuilder.Entity("EFCoreApp.Data.Lecturer", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("EFCoreApp.Data.Student", b =>
                {
                    b.Navigation("CourseRegisters");
                });
#pragma warning restore 612, 618
        }
    }
}
