using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Repository.Migrations
{
    public partial class AddMethodInfoData_ProgrammingQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ecdb40-7875-456c-a13f-3951f503adf9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a552749-b4d8-43a2-9eca-e39e0ed70691");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c0efcdf5-2eab-43ca-99df-74d7498abb5f", "b090d9fa-56c9-4e8d-962d-ec9bb68b77cf" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0efcdf5-2eab-43ca-99df-74d7498abb5f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b090d9fa-56c9-4e8d-962d-ec9bb68b77cf");

            migrationBuilder.AddColumn<string>(
                name: "Methods",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Methods",
                table: "Questions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c0efcdf5-2eab-43ca-99df-74d7498abb5f", "fa9665ef-a9e2-4eaf-a979-ddca348b652e", "Admin", "ADMIN" },
                    { "9a552749-b4d8-43a2-9eca-e39e0ed70691", "33f94bad-e0df-498c-be13-783da2f16d01", "Student", "STUDENT" },
                    { "88ecdb40-7875-456c-a13f-3951f503adf9", "b37aa976-1a2b-4b26-82d0-71fe9c566399", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastIP", "LastLogin", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b090d9fa-56c9-4e8d-962d-ec9bb68b77cf", 0, "7b30a48e-b374-4bba-afe3-a563b05129f4", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@oenik.hu", true, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADMIN@OENIK.hu", "ADMIN", "AQAAAAEAACcQAAAAEJKdeGTT/3EiHiMyk1M4gpl6PjViNvCY1kliVsdNlg/LuQ8Ex9NPt8+OFcMUTdm5sw==", null, false, "cadb87f4-aae2-4db6-82f6-de4c19c516d0", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c0efcdf5-2eab-43ca-99df-74d7498abb5f", "b090d9fa-56c9-4e8d-962d-ec9bb68b77cf" });
        }
    }
}
