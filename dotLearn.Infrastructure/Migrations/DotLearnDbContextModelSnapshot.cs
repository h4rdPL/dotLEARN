﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotLearn.Infrastructure.Database;

#nullable disable

namespace dotLearn.Infrastructure.Migrations
{
    [DbContext(typeof(DotLearnDbContext))]
    partial class DotLearnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("dotLearn.Domain.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnswerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.Benefits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DevelopmentOpportunities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("MedicalInsurance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectWork")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SportsPackage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Benefits");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.ClassEntities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("ClassCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<int>("Subject")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.Expectations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Expectations");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.FlashCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Meaning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FlashCards");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Offer");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Subject")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("QuestionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TestClassId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TestClassId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassEntitiesId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FlashCardId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<Guid?>("TestClassId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassEntitiesId");

                    b.HasIndex("FlashCardId");

                    b.HasIndex("TestClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.TestClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ActiveDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClassEntitiesId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<string>("TestName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassEntitiesId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.Answer", b =>
                {
                    b.HasOne("dotLearn.Domain.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.Benefits", b =>
                {
                    b.HasOne("dotLearn.Domain.Entities.Job", null)
                        .WithMany("Benefits")
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.ClassEntities", b =>
                {
                    b.HasOne("dotLearn.Domain.Entities.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.Expectations", b =>
                {
                    b.HasOne("dotLearn.Domain.Entities.Job", null)
                        .WithMany("Expectations")
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.Offer", b =>
                {
                    b.HasOne("dotLearn.Domain.Entities.Job", null)
                        .WithMany("Offer")
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.Question", b =>
                {
                    b.HasOne("dotLearn.Domain.Entities.TestClass", null)
                        .WithMany("Question")
                        .HasForeignKey("TestClassId");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.Student", b =>
                {
                    b.HasOne("dotLearn.Domain.Entities.ClassEntities", null)
                        .WithMany("Student")
                        .HasForeignKey("ClassEntitiesId");

                    b.HasOne("dotLearn.Domain.Entities.FlashCard", null)
                        .WithMany("Students")
                        .HasForeignKey("FlashCardId");

                    b.HasOne("dotLearn.Domain.Entities.TestClass", null)
                        .WithMany("Students")
                        .HasForeignKey("TestClassId");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.TestClass", b =>
                {
                    b.HasOne("dotLearn.Domain.Entities.ClassEntities", "ClassEntities")
                        .WithMany()
                        .HasForeignKey("ClassEntitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dotLearn.Domain.Entities.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId");

                    b.Navigation("ClassEntities");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.ClassEntities", b =>
                {
                    b.Navigation("Student");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.FlashCard", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.Job", b =>
                {
                    b.Navigation("Benefits");

                    b.Navigation("Expectations");

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("dotLearn.Domain.Entities.TestClass", b =>
                {
                    b.Navigation("Question");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
