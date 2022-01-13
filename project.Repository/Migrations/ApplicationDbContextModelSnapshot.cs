﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project.Repository.Data;

namespace project.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "05fc5ca0-8b3e-450d-bf9f-da5e7b9e525c",
                            ConcurrencyStamp = "5471f7e4-67b3-4418-8981-4fbb7dab921d",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "6debc715-5b9c-4684-8167-0d904d03b5d7",
                            ConcurrencyStamp = "4c912998-3da0-4d49-854e-0b418264ea52",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        },
                        new
                        {
                            Id = "e8dc33fa-6b55-4345-91db-54d9f89aec1e",
                            ConcurrencyStamp = "6c75947e-aa5f-44d6-9579-8a6d7902504c",
                            Name = "Teacher",
                            NormalizedName = "TEACHER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "eb23e58b-055e-4760-8652-12697ac1d89d",
                            RoleId = "05fc5ca0-8b3e-450d-bf9f-da5e7b9e525c"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("project.Domain.Models.Answer", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AnswerText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CorrectManually")
                        .HasColumnType("bit");

                    b.Property<string>("QuestionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TestResultID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("QuestionID");

                    b.HasIndex("TestResultID");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("project.Domain.Models.Course", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("project.Domain.Models.DBConnections.CourseTest", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TestID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("TestID");

                    b.ToTable("CourseTest");
                });

            modelBuilder.Entity("project.Domain.Models.DBConnections.TestProgQuestion", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProgrammingQuestionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TestID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("ProgrammingQuestionID");

                    b.HasIndex("TestID");

                    b.ToTable("TestProgQuestion");
                });

            modelBuilder.Entity("project.Domain.Models.DBConnections.TestQuestion", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("QuestionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TestID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("QuestionID");

                    b.HasIndex("TestID");

                    b.ToTable("TestQuestion");
                });

            modelBuilder.Entity("project.Domain.Models.DBConnections.UserCourse", b =>
                {
                    b.Property<string>("CourseID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("UserCourse");
                });

            modelBuilder.Entity("project.Domain.Models.Question", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CorrectManually")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedById")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsShared")
                        .HasColumnType("bit");

                    b.Property<double>("MaxPoints")
                        .HasColumnType("float");

                    b.Property<byte[]>("PictureData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PictureExtensionType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("QuestionType")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("CreatedById");

                    b.ToTable("Questions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Question");
                });

            modelBuilder.Entity("project.Domain.Models.QuestionLabel", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LabelText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("QuestionID");

                    b.ToTable("QuestionLabels");
                });

            modelBuilder.Entity("project.Domain.Models.Test", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("AllowedTakeLength")
                        .HasColumnType("time");

                    b.Property<string>("CreatedById")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsLateSubmissionAllowed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsShared")
                        .HasColumnType("bit");

                    b.Property<double>("MaxPoints")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("CreatedById");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("project.Domain.Models.TestResult", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FinishTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCorrectionFinished")
                        .HasColumnType("bit");

                    b.Property<double>("PointResult")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TestID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("TestID");

                    b.HasIndex("UserId");

                    b.ToTable("TestResults");
                });

            modelBuilder.Entity("project.Domain.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("CreatedById")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastIP")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasIndex("CreatedById");

                    b.HasDiscriminator().HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = "eb23e58b-055e-4760-8652-12697ac1d89d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a8e6360a-8ca4-427f-af3c-0168fb9706b8",
                            Email = "admin@oenik.hu",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@OENIK.hu",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEKPxIPrY36sUWG2F7iu+/BgHt02sFbp9sEMQXwjBO/ZPe/KA/yb3TSRz+fxOp1GmrA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "71eb09b3-06ab-4596-bbe7-2dffdab4f01c",
                            TwoFactorEnabled = false,
                            UserName = "admin",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastLogin = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("project.Domain.Models.ProgrammingQuestion", b =>
                {
                    b.HasBaseType("project.Domain.Models.Question");

                    b.Property<string>("ExpectedOutput")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OptimalNumberOfLines")
                        .HasColumnType("int");

                    b.Property<int>("ReferenceComplexityLevel")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("ReferenceRuntime")
                        .HasColumnType("time");

                    b.HasDiscriminator().HasValue("ProgrammingQuestion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("project.Domain.Models.Answer", b =>
                {
                    b.HasOne("project.Domain.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionID");

                    b.HasOne("project.Domain.Models.TestResult", null)
                        .WithMany("Answers")
                        .HasForeignKey("TestResultID");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("project.Domain.Models.DBConnections.CourseTest", b =>
                {
                    b.HasOne("project.Domain.Models.Course", "Course")
                        .WithMany("CourseTests")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("project.Domain.Models.Test", "Test")
                        .WithMany("CourseTests")
                        .HasForeignKey("TestID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Course");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("project.Domain.Models.DBConnections.TestProgQuestion", b =>
                {
                    b.HasOne("project.Domain.Models.ProgrammingQuestion", "ProgrammingQuestion")
                        .WithMany("TestProgQuestions")
                        .HasForeignKey("ProgrammingQuestionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("project.Domain.Models.Test", "Test")
                        .WithMany("TestProgQuestions")
                        .HasForeignKey("TestID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ProgrammingQuestion");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("project.Domain.Models.DBConnections.TestQuestion", b =>
                {
                    b.HasOne("project.Domain.Models.Question", "Question")
                        .WithMany("TestQuestions")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("project.Domain.Models.Test", "Test")
                        .WithMany("TestQuestions")
                        .HasForeignKey("TestID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Question");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("project.Domain.Models.DBConnections.UserCourse", b =>
                {
                    b.HasOne("project.Domain.Models.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project.Domain.Models.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("project.Domain.Models.Question", b =>
                {
                    b.HasOne("project.Domain.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("project.Domain.Models.QuestionLabel", b =>
                {
                    b.HasOne("project.Domain.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionID");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("project.Domain.Models.Test", b =>
                {
                    b.HasOne("project.Domain.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("project.Domain.Models.TestResult", b =>
                {
                    b.HasOne("project.Domain.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID");

                    b.HasOne("project.Domain.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestID");

                    b.HasOne("project.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Course");

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("project.Domain.Models.User", b =>
                {
                    b.HasOne("project.Domain.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("project.Domain.Models.Course", b =>
                {
                    b.Navigation("CourseTests");

                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("project.Domain.Models.Question", b =>
                {
                    b.Navigation("TestQuestions");
                });

            modelBuilder.Entity("project.Domain.Models.Test", b =>
                {
                    b.Navigation("CourseTests");

                    b.Navigation("TestProgQuestions");

                    b.Navigation("TestQuestions");
                });

            modelBuilder.Entity("project.Domain.Models.TestResult", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("project.Domain.Models.User", b =>
                {
                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("project.Domain.Models.ProgrammingQuestion", b =>
                {
                    b.Navigation("TestProgQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}
