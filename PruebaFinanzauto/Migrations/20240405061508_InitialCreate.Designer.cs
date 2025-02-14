﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaFinanzauto;

#nullable disable

namespace PruebaFinanzauto.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240405061508_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PruebaFinanzauto.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6746),
                            Description = "Description for Course A",
                            Name = "Course A",
                            Updated_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6746)
                        },
                        new
                        {
                            Id = 2,
                            Created_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6747),
                            Description = "Description for Course B",
                            Name = "Course B",
                            Updated_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6748)
                        });
                });

            modelBuilder.Entity("PruebaFinanzauto.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = 1,
                            SubjectId = 1,
                            Updated_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = 85.0
                        },
                        new
                        {
                            Id = 2,
                            Created_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = 1,
                            SubjectId = 2,
                            Updated_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = 90.0
                        },
                        new
                        {
                            Id = 3,
                            Created_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = 2,
                            SubjectId = 1,
                            Updated_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = 78.0
                        },
                        new
                        {
                            Id = 4,
                            Created_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = 2,
                            SubjectId = 2,
                            Updated_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = 92.0
                        },
                        new
                        {
                            Id = 5,
                            Created_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = 3,
                            SubjectId = 3,
                            Updated_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = 88.0
                        },
                        new
                        {
                            Id = 6,
                            Created_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = 3,
                            SubjectId = 4,
                            Updated_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = 91.0
                        },
                        new
                        {
                            Id = 7,
                            Created_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = 4,
                            SubjectId = 3,
                            Updated_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = 85.0
                        },
                        new
                        {
                            Id = 8,
                            Created_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = 4,
                            SubjectId = 4,
                            Updated_at = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = 90.0
                        });
                });

            modelBuilder.Entity("PruebaFinanzauto.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Cr23 #45-5",
                            CourseId = 1,
                            Created_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6635),
                            Email = "prueba@gmail.com",
                            EnrollmentDate = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6634),
                            LastName = "Till",
                            Name = "Maria",
                            PhoneNumber = "3155408709",
                            Updated_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6635)
                        },
                        new
                        {
                            Id = 2,
                            Address = "Edificio Casa Blanca apto 208",
                            CourseId = 1,
                            Created_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6638),
                            Email = "prueba2@gmail.com",
                            EnrollmentDate = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6637),
                            LastName = "Till",
                            Name = "Julia",
                            PhoneNumber = "3155988709",
                            Updated_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6638)
                        },
                        new
                        {
                            Id = 3,
                            Address = "La Castellana Cr 12 #45",
                            CourseId = 2,
                            Created_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6640),
                            Email = "prueba3@gmail.com",
                            EnrollmentDate = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6640),
                            LastName = "Henao",
                            Name = "Pablo",
                            PhoneNumber = "3175988709",
                            Updated_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6640)
                        },
                        new
                        {
                            Id = 4,
                            Address = "La Castellana Cr 12 #45",
                            CourseId = 2,
                            Created_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6642),
                            Email = "prueba4@gmail.com",
                            EnrollmentDate = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6642),
                            LastName = "Hidalgo",
                            Name = "Juan",
                            PhoneNumber = "3255988709",
                            Updated_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6642)
                        });
                });

            modelBuilder.Entity("PruebaFinanzauto.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Created_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6731),
                            Description = "Materia basada en hechos cientificos",
                            Name = "Ciencias Naturales",
                            Updated_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6732)
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            Created_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6733),
                            Description = "Materia basada en numeros",
                            Name = "Matematicas",
                            Updated_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6734)
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 2,
                            Created_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6735),
                            Description = "Materia basada en la literatura espaniola",
                            Name = "Espaniol",
                            Updated_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6735)
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 2,
                            Created_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6736),
                            Description = "Materia basada en la historia y hechos reales",
                            Name = "Sociales",
                            Updated_at = new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6736)
                        });
                });

            modelBuilder.Entity("PruebaFinanzauto.Models.Grade", b =>
                {
                    b.HasOne("PruebaFinanzauto.Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PruebaFinanzauto.Models.Subject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("PruebaFinanzauto.Models.Student", b =>
                {
                    b.HasOne("PruebaFinanzauto.Models.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("PruebaFinanzauto.Models.Subject", b =>
                {
                    b.HasOne("PruebaFinanzauto.Models.Course", "Course")
                        .WithMany("Subjects")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("PruebaFinanzauto.Models.Course", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("PruebaFinanzauto.Models.Student", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("PruebaFinanzauto.Models.Subject", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
