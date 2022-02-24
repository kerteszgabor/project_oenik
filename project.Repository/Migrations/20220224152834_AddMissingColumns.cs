using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Repository.Migrations
{
    public partial class AddMissingColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1467e099-d101-48e5-92fc-24d2885961c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e6f03cf-c406-44c2-9189-f4556aca57a0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0bf65ce1-f114-49d9-b073-96ad19263346", "9494ec51-b92d-430b-b813-c18dc5dd7568" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bf65ce1-f114-49d9-b073-96ad19263346");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9494ec51-b92d-430b-b813-c18dc5dd7568");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0bf65ce1-f114-49d9-b073-96ad19263346", "bc0b7460-679c-4ea0-ae8c-cb8097eea847", "Admin", "ADMIN" },
                    { "1467e099-d101-48e5-92fc-24d2885961c8", "fe333760-dde9-4fc1-9537-be80c5e0013c", "Student", "STUDENT" },
                    { "6e6f03cf-c406-44c2-9189-f4556aca57a0", "9ca62739-b18d-4cc9-89d6-1283effb31c7", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastIP", "LastLogin", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9494ec51-b92d-430b-b813-c18dc5dd7568", 0, "44f5c0d6-84cf-4773-b4a5-2c6e931c3ff2", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@oenik.hu", true, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADMIN@OENIK.hu", "ADMIN", "AQAAAAEAACcQAAAAEOgRxmI2icyHTeuiGZXFxOE1xIqxLK2DtciFrN4rd8ZypxntMQYZp3FkJX3Bi/+w8w==", null, false, "f7a6fa24-9014-4e94-bc40-967b29d6e15e", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0bf65ce1-f114-49d9-b073-96ad19263346", "9494ec51-b92d-430b-b813-c18dc5dd7568" });
        }
    }
}
