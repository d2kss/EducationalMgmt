﻿// <auto-generated />
using System;
using EducationalInstitute.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EducationalInstitute.Migrations
{
    [DbContext(typeof(EducationalInstituteContext))]
    partial class EducationalInstituteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EducationalInstitute.Models.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamId"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateofExam")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsActive")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ExamId");

                    b.HasIndex("ClassId");

                    b.HasIndex("SectionId");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("EducationalInstitute.Models.Fees", b =>
                {
                    b.Property<int>("FeesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeesId"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IsActive")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FeesId");

                    b.HasIndex("ClassId");

                    b.ToTable("Fees");
                });

            modelBuilder.Entity("EducationalInstitute.Models.SClass", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IsActive")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ClassId");

                    b.ToTable("SClass");
                });

            modelBuilder.Entity("EducationalInstitute.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectionId"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IsActive")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SectionId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("EducationalInstitute.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IsActive")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MotherName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<double>("TotalFees")
                        .HasColumnType("float");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassID");

                    b.HasIndex("SectionId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("EducationalInstitute.Models.Subject", b =>
                {
                    b.Property<int>("subjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("subjectId"));

                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IsActive")
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("subjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("subjectId");

                    b.HasIndex("ClassID");

                    b.HasIndex("SectionId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("EducationalInstitute.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IsActive")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MotherName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SubjectExpert")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TeacherId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("EducationalInstitute.Models.Exam", b =>
                {
                    b.HasOne("EducationalInstitute.Models.SClass", "SClass")
                        .WithMany("Exam")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EducationalInstitute.Models.Section", "Section")
                        .WithMany("Exam")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SClass");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("EducationalInstitute.Models.Fees", b =>
                {
                    b.HasOne("EducationalInstitute.Models.SClass", "SClass")
                        .WithMany("Fees")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SClass");
                });

            modelBuilder.Entity("EducationalInstitute.Models.Student", b =>
                {
                    b.HasOne("EducationalInstitute.Models.SClass", "SClass")
                        .WithMany("Students")
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EducationalInstitute.Models.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EducationalInstitute.Models.Teacher", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherId");

                    b.Navigation("SClass");

                    b.Navigation("Section");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EducationalInstitute.Models.Subject", b =>
                {
                    b.HasOne("EducationalInstitute.Models.SClass", "SClass")
                        .WithMany("Subjects")
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EducationalInstitute.Models.Section", "Section")
                        .WithMany("Subjects")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SClass");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("EducationalInstitute.Models.SClass", b =>
                {
                    b.Navigation("Exam");

                    b.Navigation("Fees");

                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("EducationalInstitute.Models.Section", b =>
                {
                    b.Navigation("Exam");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("EducationalInstitute.Models.Teacher", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
