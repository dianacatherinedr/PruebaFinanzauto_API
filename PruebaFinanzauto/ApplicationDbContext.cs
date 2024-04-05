using Microsoft.EntityFrameworkCore;
using PruebaFinanzauto.Models;
using System.Diagnostics;

namespace PruebaFinanzauto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
           .HasOne<Course>(s => s.Course)
           .WithMany(c => c.Students)
           .HasForeignKey(s => s.CourseId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasMany<Student>(c => c.Students)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subject>()
                .HasOne<Course>(s => s.Course)
                .WithMany(c => c.Subjects)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grade>()
                .HasOne<Student>(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grade>()
                .HasOne<Subject>(g => g.Subject)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    Name = "Maria",
                    LastName = "Till",
                    PhoneNumber = "3155408709",
                    Email = "prueba@gmail.com",
                    EnrollmentDate = DateTime.Now,
                    Address = "Cr23 #45-5",
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now,
                    CourseId = 1
                },
    new Student()
    {
        Id = 2,
        Name = "Julia",
        LastName = "Till",
        PhoneNumber = "3155988709",
        Email = "prueba2@gmail.com",
        EnrollmentDate = DateTime.Now,
        Address = "Edificio Casa Blanca apto 208",
        Created_at = DateTime.Now,
        Updated_at = DateTime.Now,
        CourseId = 1
    },
    new Student()
    {
        Id = 3,
        Name = "Pablo",
        LastName = "Henao",
        PhoneNumber = "3175988709",
        Email = "prueba3@gmail.com",
        EnrollmentDate = DateTime.Now,
        Address = "La Castellana Cr 12 #45",
        Created_at = DateTime.Now,
        Updated_at = DateTime.Now,
        CourseId = 2
    },
    new Student()
    {
        Id = 4,
        Name = "Juan",
        LastName = "Hidalgo",
        PhoneNumber = "3255988709",
        Email = "prueba4@gmail.com",
        EnrollmentDate = DateTime.Now,
        Address = "La Castellana Cr 12 #45",
        Created_at = DateTime.Now,
        Updated_at = DateTime.Now,
        CourseId = 2
    });

            modelBuilder.Entity<Subject>().HasData(
                new Subject()
                {
                    Id = 1,
                    Name = "Ciencias Naturales",
                    Description = "Materia basada en hechos cientificos",
                    CourseId = 1,
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now,
                },
    new Subject()
    {
        Id = 2,
        Name = "Matematicas",
        Description = "Materia basada en numeros",
        CourseId = 1,
        Created_at = DateTime.Now,
        Updated_at = DateTime.Now,
    },
    new Subject()
    {
        Id = 3,
        Name = "Espaniol",
        Description = "Materia basada en la literatura espaniola",
        CourseId = 2,
        Created_at = DateTime.Now,
        Updated_at = DateTime.Now,
    },
    new Subject()
    {
        Id = 4,
        Name = "Sociales",
        Description = "Materia basada en la historia y hechos reales",
        CourseId = 2,
        Created_at = DateTime.Now,
        Updated_at = DateTime.Now,
    });

            modelBuilder.Entity<Course>().HasData(
    new Course()
    {
        Id = 1,
        Name = "Course A",
        Description = "Description for Course A",
        Created_at = DateTime.Now,
        Updated_at = DateTime.Now
    },
    new Course()
    {
        Id = 2,
        Name = "Course B",
        Description = "Description for Course B",
        Created_at = DateTime.Now,
        Updated_at = DateTime.Now
    }

);
            modelBuilder.Entity<Grade>().HasData(
    new Grade()
    {
        Id = 1,
        StudentId = 1,
        SubjectId = 1,
        Value = 85
    },
    new Grade()
    {
        Id = 2,
        StudentId = 1,
        SubjectId = 2,
        Value = 90
    },
    new Grade()
    {
        Id = 3,
        StudentId = 2,
        SubjectId = 1,
        Value = 78
    },
    new Grade()
    {
        Id = 4,
        StudentId = 2,
        SubjectId = 2,
        Value = 92
    },
    new Grade()
    {
        Id = 5,
        StudentId = 3,
        SubjectId = 3,
        Value = 88
    },
    new Grade()
    {
        Id = 6,
        StudentId = 3,
        SubjectId = 4,
        Value = 91
    },
    new Grade()
    {
        Id = 7,
        StudentId = 4,
        SubjectId = 3,
        Value = 85
    },
    new Grade()
    {
        Id = 8,
        StudentId = 4,
        SubjectId = 4,
        Value = 90
    }
);


        }

    }
}
