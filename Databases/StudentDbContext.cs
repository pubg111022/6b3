using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using pdf6b2.Models;
using pdf6b3.Databases.EnitityTypeConfiguration;
using pdf6b3.Databases.EntitiesTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pdf6b3.Databases
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
        

        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Mark> Marks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Student>(new StudentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration<Subject>(new SubjectEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration<Mark>(new MarkEntityTypeConfiguration());

            modelBuilder.Entity<Mark>() 
            .HasOne<Student>(s => s.Student)
            .WithMany(g => g.Mark)
            .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<Mark>()
           .HasOne<Subject>(s => s.Subject)
           .WithMany(g => g.Mark)
           .HasForeignKey(s => s.SubjectId);
        }
    }
}
