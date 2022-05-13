using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Repository.Migrations
{
    public partial class Update_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c1782e7-140a-482b-91a5-1ad14b753195");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75e39754-bf84-43a8-91ae-c68f58f32f2b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0df7e3eb-4b67-423a-b719-bffe8609f65b", "6332847f-fa11-4942-acc9-a24bb00298ac" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0df7e3eb-4b67-423a-b719-bffe8609f65b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6332847f-fa11-4942-acc9-a24bb00298ac");

            migrationBuilder.AddColumn<string>(
                name: "DisallowedWords",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequiredWords",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2adb5394-d1ad-488b-84fc-ec2883b26626", "19656681-a3d7-413a-96f5-b937c7e8b369", "Student", "STUDENT" },
                    { "5700dca6-1550-4887-9d04-8d67ac2f0fdc", "0aadd444-cf53-4ea8-8afe-b176ab1deb3b", "Admin", "ADMIN" },
                    { "f9daca0d-3b38-4569-8c7f-d6865b2e840c", "e2c40d7e-7fa7-4b70-baf8-74284afb029f", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastIP", "LastLogin", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "25f86929-8984-4065-99b9-13998b74e9b9", 0, "4c2b366a-cc98-4591-b754-cf71af1b86ae", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@oenik.hu", true, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADMIN@OENIK.hu", "ADMIN", "AQAAAAEAACcQAAAAEImMA2SZY3j7vW/q1GeaUzKFQ0aln8eFim4YewmZtQ/M/7m1X/FywxSGHn+uPa2hrg==", null, false, "6858c11c-3b0d-4004-8953-3c8b85101b8d", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5700dca6-1550-4887-9d04-8d67ac2f0fdc", "25f86929-8984-4065-99b9-13998b74e9b9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2adb5394-d1ad-488b-84fc-ec2883b26626");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9daca0d-3b38-4569-8c7f-d6865b2e840c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5700dca6-1550-4887-9d04-8d67ac2f0fdc", "25f86929-8984-4065-99b9-13998b74e9b9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5700dca6-1550-4887-9d04-8d67ac2f0fdc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "25f86929-8984-4065-99b9-13998b74e9b9");

            migrationBuilder.DropColumn(
                name: "DisallowedWords",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "RequiredWords",
                table: "Questions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0df7e3eb-4b67-423a-b719-bffe8609f65b", "35434aed-53ed-4f60-a6bc-95e6a9a1da6e", "Admin", "ADMIN" },
                    { "1c1782e7-140a-482b-91a5-1ad14b753195", "63f6c2f6-f970-4a0e-b83b-1bd85d83163e", "Student", "STUDENT" },
                    { "75e39754-bf84-43a8-91ae-c68f58f32f2b", "a8d48c26-9bd8-42e3-84a0-4d8c7f9bfcbf", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastIP", "LastLogin", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6332847f-fa11-4942-acc9-a24bb00298ac", 0, "04be1988-fcee-4bab-b1ad-d9aff9707e7e", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@oenik.hu", true, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADMIN@OENIK.hu", "ADMIN", "AQAAAAEAACcQAAAAEEudkrDDcHzu2HTkRHIqyBvcNZlpxrYrq+kGZHmm+AsYAU3Ga4fhkQfYbzVO5EP+og==", null, false, "c8be31c7-4682-4f9e-8b31-965d4797f6b6", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0df7e3eb-4b67-423a-b719-bffe8609f65b", "6332847f-fa11-4942-acc9-a24bb00298ac" });
        }
    }
}
