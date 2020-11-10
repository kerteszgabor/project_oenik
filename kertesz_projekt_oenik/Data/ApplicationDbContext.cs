using kertesz_projekt_oenik.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kertesz_projekt_oenik.Data
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
        }

        public DbSet<User> Students { get; set; }
        public DbSet<User> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionLabel> QuestionLabels { get; set; }
        public DbSet<ProgrammingQuestion> ProgrammingQuestions { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        
    }
}
