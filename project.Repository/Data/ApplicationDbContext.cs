using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using project.Domain.DTO.ClassReport;
using project.Domain.Helpers.ClassReportBuilder;
using project.Domain.Models;
using project.Domain.Models.DBConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Repository.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string roleID = Guid.NewGuid().ToString();
            string adminID = Guid.NewGuid().ToString();

            //Create admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleID,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            // Create Teacher and Student roles
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Student",
                NormalizedName = "STUDENT"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Teacher",
                NormalizedName = "TEACHER"
            });

            //Seed an admin user into the role
            builder.Entity<User>().HasData(new User()
            {
                Id = adminID,
                UserName = "admin",
                Email = "admin@oenik.hu",
                NormalizedEmail = "ADMIN@OENIK.hu",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "test123")
            });

            //insert into connecting table
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleID,
                UserId = adminID
            });

            builder.Entity<UserCourse>().HasKey(uc => new
            {
                uc.CourseID,
                uc.UserID
            });
            //  builder.Entity<CourseTest>().HasNoKey();

            builder.Entity<TestResult>().Property(p => p.ProgQuestionReports)
            .HasConversion(
                 v => JsonConvert.SerializeObject(v),
                 v => JsonConvert.DeserializeObject<List<ClassReport>>(v));

            builder.Entity<ProgrammingQuestion>().Property(p => p.Methods)
            .HasConversion(
                 v => JsonConvert.SerializeObject(v),
                 v => JsonConvert.DeserializeObject<List<MethodInfoData>>(v));

            SetupManyToManyMaps(builder);
        }

        private void SetupManyToManyMaps(ModelBuilder builder)
        {
            builder.Entity<UserCourse>()
                .HasOne(uc => uc.Course)
                .WithMany(c => c.UserCourses)
                .HasForeignKey(uc => uc.CourseID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserCourse>()
                .HasOne(uc => uc.User)
                .WithMany(c => c.UserCourses)
                .HasForeignKey(uc => uc.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CourseTest>()
               .HasOne(ct => ct.Course)
               .WithMany(t => t.CourseTests)
               .HasForeignKey(ct => ct.CourseID)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CourseTest>()
                .HasOne(ct => ct.Test)
                .WithMany(c => c.CourseTests)
                .HasForeignKey(ct => ct.TestID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TestProgQuestion>()
               .HasOne(tp => tp.Test)
               .WithMany(t => t.TestProgQuestions)
               .HasForeignKey(tp => tp.TestID)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TestProgQuestion>()
                .HasOne(tp => tp.ProgrammingQuestion)
                .WithMany(p => p.TestProgQuestions)
                .HasForeignKey(tp => tp.ProgrammingQuestionID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TestQuestion>()
               .HasOne(tq => tq.Test)
               .WithMany(t => t.TestQuestions)
               .HasForeignKey(tq => tq.TestID)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TestQuestion>()
                .HasOne(tq => tq.Question)
                .WithMany(q => q.TestQuestions)
                .HasForeignKey(tq => tq.QuestionID)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionLabel> QuestionLabels { get; set; }
        public DbSet<ProgrammingQuestion> ProgrammingQuestions { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
    }
}
