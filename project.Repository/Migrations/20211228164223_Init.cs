using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33104f63-7f06-408e-a067-20c2770e41af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f865e952-09f1-4a03-a2e0-d7c56e224f5e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "30df0a43-212e-4956-8b6a-f724b4ecae57", "b8006249-a533-41ea-bf7b-f0a6d08a3a52" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30df0a43-212e-4956-8b6a-f724b4ecae57");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8006249-a533-41ea-bf7b-f0a6d08a3a52");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d1e647a-53de-4fbe-b85c-17327553e023", "a9e7c1e2-0a64-407c-8f11-462bac749e53", "Admin", "ADMIN" },
                    { "f4b429c1-8a73-441f-b94d-773a1ff73a6f", "08e4364c-bd33-4d7e-b407-ee088771ed99", "Student", "STUDENT" },
                    { "48174fc2-c46f-4640-a59d-19660e6fa1f9", "8bddb9fb-8c45-4511-8801-2b90eb40f6ad", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastIP", "LastLogin", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4b1fa6f9-cae9-4b84-87f9-b8eb3c33718c", 0, "29e72888-eed7-4ce2-8148-3a0588a6316c", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@oenik.hu", true, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADMIN@OENIK.hu", "ADMIN", "AQAAAAEAACcQAAAAEGhEBnB5+eIe/bUF6WPRBqNcInrhvX6u427g4r6f7Mg2q2kr9Ya+GQviBqGzKgplkA==", null, false, "bb132139-f0ef-45ee-92a9-81db47952fb6", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2d1e647a-53de-4fbe-b85c-17327553e023", "4b1fa6f9-cae9-4b84-87f9-b8eb3c33718c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48174fc2-c46f-4640-a59d-19660e6fa1f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4b429c1-8a73-441f-b94d-773a1ff73a6f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d1e647a-53de-4fbe-b85c-17327553e023", "4b1fa6f9-cae9-4b84-87f9-b8eb3c33718c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d1e647a-53de-4fbe-b85c-17327553e023");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b1fa6f9-cae9-4b84-87f9-b8eb3c33718c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30df0a43-212e-4956-8b6a-f724b4ecae57", "301f3394-8e09-4505-ae0d-5fcd8ddb55d0", "Admin", "ADMIN" },
                    { "f865e952-09f1-4a03-a2e0-d7c56e224f5e", "3ce7af4f-7e68-4d8f-98b7-c4302df9a2e2", "Student", "STUDENT" },
                    { "33104f63-7f06-408e-a067-20c2770e41af", "892dfa85-f756-4e0e-bbf2-849573a295e3", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastIP", "LastLogin", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b8006249-a533-41ea-bf7b-f0a6d08a3a52", 0, "a3972074-024f-46bc-9bae-e15f20642b16", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@oenik.hu", true, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADMIN@OENIK.hu", "ADMIN", "AQAAAAEAACcQAAAAEHkxL77stHEelyleDT/Sdlba5pzbBFCfNMfSCAdKXmOIdrRZ/w76iM5zg51BPncLDA==", null, false, "8f3aa5ad-22fb-4d10-b792-86328fee360b", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "30df0a43-212e-4956-8b6a-f724b4ecae57", "b8006249-a533-41ea-bf7b-f0a6d08a3a52" });
        }
    }
}
