﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kertesz_projekt_oenik.Data;

namespace kertesz_projekt_oenik.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201110213026_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

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
                            Id = "19d63ac4-ffcc-4315-bb49-870fb1f3679d",
                            ConcurrencyStamp = "a244d6a1-a079-483b-96bf-c772e81da7ba",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "c0d0e24b-f1b9-461e-9ab5-26a9f82cdbb6",
                            ConcurrencyStamp = "9902aa50-2cab-44d8-beea-2e6a27ecefad",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        },
                        new
                        {
                            Id = "bb7373f8-83dc-47f4-bb9e-45379e163430",
                            ConcurrencyStamp = "a4adc168-0b46-42af-9f1a-b7a17abdbd14",
                            Name = "Teacher",
                            NormalizedName = "TEACHER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                            UserId = "f978232d-8908-41ec-afdd-4cf081cc0baa",
                            RoleId = "19d63ac4-ffcc-4315-bb49-870fb1f3679d"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.Answer", b =>
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

            modelBuilder.Entity("kertesz_projekt_oenik.Models.Course", b =>
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

            modelBuilder.Entity("kertesz_projekt_oenik.Models.DBConnections.CourseTest", b =>
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

            modelBuilder.Entity("kertesz_projekt_oenik.Models.DBConnections.TestProgQuestion", b =>
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

            modelBuilder.Entity("kertesz_projekt_oenik.Models.DBConnections.TestQuestion", b =>
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

            modelBuilder.Entity("kertesz_projekt_oenik.Models.DBConnections.UserCourse", b =>
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

            modelBuilder.Entity("kertesz_projekt_oenik.Models.ProgrammingQuestion", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExpectedOutput")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsShared")
                        .HasColumnType("bit");

                    b.Property<double>("MaxPoints")
                        .HasColumnType("float");

                    b.Property<int>("OptimalNumberOfLines")
                        .HasColumnType("int");

                    b.Property<byte[]>("PictureData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PictureExtensionType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("QuestionType")
                        .HasColumnType("int");

                    b.Property<int>("ReferenceComplexityLevel")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("ReferenceRuntime")
                        .HasColumnType("time");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("ProgrammingQuestions");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.Question", b =>
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
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.QuestionLabel", b =>
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

            modelBuilder.Entity("kertesz_projekt_oenik.Models.Test", b =>
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

            modelBuilder.Entity("kertesz_projekt_oenik.Models.TestResult", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FinishTime")
                        .HasColumnType("datetime2");

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

            modelBuilder.Entity("kertesz_projekt_oenik.Models.User", b =>
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
                            Id = "f978232d-8908-41ec-afdd-4cf081cc0baa",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "83df4b6e-0993-4c42-b87b-96d343d0283c",
                            Email = "admin@oenik.hu",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@OENIK.hu",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAENUSFEGilh715YhssJRdipvaMYOdslEE3MTLyRwURbA8B+YeFCvtBLVW/Q6B03L0gg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "da4fa86c-5eac-4b45-a4aa-ad495aa45b5b",
                            TwoFactorEnabled = false,
                            UserName = "admin",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastLogin = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
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

            modelBuilder.Entity("kertesz_projekt_oenik.Models.Answer", b =>
                {
                    b.HasOne("kertesz_projekt_oenik.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionID");

                    b.HasOne("kertesz_projekt_oenik.Models.TestResult", null)
                        .WithMany("Answers")
                        .HasForeignKey("TestResultID");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.DBConnections.CourseTest", b =>
                {
                    b.HasOne("kertesz_projekt_oenik.Models.Course", "Course")
                        .WithMany("CourseTests")
                        .HasForeignKey("CourseID");

                    b.HasOne("kertesz_projekt_oenik.Models.Test", "Test")
                        .WithMany("CourseTests")
                        .HasForeignKey("TestID");

                    b.Navigation("Course");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.DBConnections.TestProgQuestion", b =>
                {
                    b.HasOne("kertesz_projekt_oenik.Models.ProgrammingQuestion", "ProgrammingQuestion")
                        .WithMany("TestProgQuestions")
                        .HasForeignKey("ProgrammingQuestionID");

                    b.HasOne("kertesz_projekt_oenik.Models.Test", "Test")
                        .WithMany("TestProgQuestions")
                        .HasForeignKey("TestID");

                    b.Navigation("ProgrammingQuestion");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.DBConnections.TestQuestion", b =>
                {
                    b.HasOne("kertesz_projekt_oenik.Models.Question", "Question")
                        .WithMany("TestQuestions")
                        .HasForeignKey("QuestionID");

                    b.HasOne("kertesz_projekt_oenik.Models.Test", "Test")
                        .WithMany("TestQuestions")
                        .HasForeignKey("TestID");

                    b.Navigation("Question");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.DBConnections.UserCourse", b =>
                {
                    b.HasOne("kertesz_projekt_oenik.Models.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kertesz_projekt_oenik.Models.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.Question", b =>
                {
                    b.HasOne("kertesz_projekt_oenik.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.QuestionLabel", b =>
                {
                    b.HasOne("kertesz_projekt_oenik.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionID");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.Test", b =>
                {
                    b.HasOne("kertesz_projekt_oenik.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.TestResult", b =>
                {
                    b.HasOne("kertesz_projekt_oenik.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID");

                    b.HasOne("kertesz_projekt_oenik.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestID");

                    b.HasOne("kertesz_projekt_oenik.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Course");

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.User", b =>
                {
                    b.HasOne("kertesz_projekt_oenik.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.Course", b =>
                {
                    b.Navigation("CourseTests");

                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.ProgrammingQuestion", b =>
                {
                    b.Navigation("TestProgQuestions");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.Question", b =>
                {
                    b.Navigation("TestQuestions");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.Test", b =>
                {
                    b.Navigation("CourseTests");

                    b.Navigation("TestProgQuestions");

                    b.Navigation("TestQuestions");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.TestResult", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("kertesz_projekt_oenik.Models.User", b =>
                {
                    b.Navigation("UserCourses");
                });
#pragma warning restore 612, 618
        }
    }
}