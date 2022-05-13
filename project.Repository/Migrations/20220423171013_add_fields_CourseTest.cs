using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Repository.Migrations
{
    public partial class add_fields_CourseTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "017907bf-b1ba-48aa-a73b-c9471d801824");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04d36967-ee1a-4485-9caf-367489bf3618");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "62a10600-b14f-4d84-b00f-b555119133a6", "a1f7fd39-9ac3-4470-93f8-72af30c636e8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62a10600-b14f-4d84-b00f-b555119133a6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1f7fd39-9ac3-4470-93f8-72af30c636e8");

            migrationBuilder.AddColumn<string>(
                name: "AllowedIPSubnet",
                table: "CourseTest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "CourseTest",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AllowedIPSubnet",
                table: "CourseTest");

            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "CourseTest");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "017907bf-b1ba-48aa-a73b-c9471d801824", "f6f30bed-8b61-4e97-a200-f61160d046e2", "Teacher", "TEACHER" },
                    { "04d36967-ee1a-4485-9caf-367489bf3618", "fae38097-b3d5-4f9f-91d5-62cd3d7d33ac", "Student", "STUDENT" },
                    { "62a10600-b14f-4d84-b00f-b555119133a6", "e61bf85d-7c3f-482d-8dbd-8bd22743afb8", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastIP", "LastLogin", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a1f7fd39-9ac3-4470-93f8-72af30c636e8", 0, "6abeeed9-6892-4ab9-b83b-6f830a0ef9fd", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@oenik.hu", true, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADMIN@OENIK.hu", "ADMIN", "AQAAAAEAACcQAAAAEAo4lokBwILR5WsVbFON2wiYcBQt1dhNMyqDw+b+MhxU2Yd8dXE8yBA+xvJlAt4CWw==", null, false, "77e42890-436b-4d0d-9d1f-55ee5e493598", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "62a10600-b14f-4d84-b00f-b555119133a6", "a1f7fd39-9ac3-4470-93f8-72af30c636e8" });
        }
    }
}
