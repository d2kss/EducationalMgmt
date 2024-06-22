using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EducationalInstitute.Models;

namespace EducationalInstitute.Data
{
    public class EducationalInstituteContext : DbContext
    {
        public EducationalInstituteContext (DbContextOptions<EducationalInstituteContext> options)
            : base(options)
        {
        }

        public DbSet<EducationalInstitute.Models.SClass> SClass { get; set; } = default!;
        public DbSet<EducationalInstitute.Models.Fees> Fees { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SClass>()
                .HasMany(e => e.Fees)
                .WithOne(e => e.SClass)
                .HasForeignKey(e => e.ClassId);

            modelBuilder.Entity<SClass>()
                .HasMany(e=>e.Students)
                .WithOne(e=>e.SClass)
                .HasForeignKey(e=>e.ClassID);


            modelBuilder.Entity<SClass>()
                .HasMany(e => e.Subjects)
                .WithOne(e => e.SClass)
                .HasForeignKey(e => e.ClassID);

            modelBuilder.Entity<Section>()
               .HasMany(e => e.Subjects)
               .WithOne(e => e.Section)
               .HasForeignKey(e => e.SectionId);

            modelBuilder.Entity<SClass>()
                .HasMany(e=>e.Exam)
                .WithOne(e=>e.SClass)
                .HasForeignKey(e=>e.ClassId);
            modelBuilder.Entity<Section>()
               .HasMany(e => e.Exam)
               .WithOne(e => e.Section)
               .HasForeignKey(e => e.SectionId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<EducationalInstitute.Models.Teacher> Teacher { get; set; } = default!;
        public DbSet<EducationalInstitute.Models.Section> Section { get; set; } = default!;
        public DbSet<EducationalInstitute.Models.Student> Student { get; set; } = default!;
        public DbSet<EducationalInstitute.Models.Subject> Subject { get; set; } = default!;
        public DbSet<EducationalInstitute.Models.Exam> Exam { get; set; } = default!;


    }
}
