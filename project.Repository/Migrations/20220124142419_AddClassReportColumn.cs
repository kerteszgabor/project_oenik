using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Repository.Migrations
{
    public partial class AddClassReportColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6debc715-5b9c-4684-8167-0d904d03b5d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8dc33fa-6b55-4345-91db-54d9f89aec1e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "05fc5ca0-8b3e-450d-bf9f-da5e7b9e525c", "eb23e58b-055e-4760-8652-12697ac1d89d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05fc5ca0-8b3e-450d-bf9f-da5e7b9e525c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb23e58b-055e-4760-8652-12697ac1d89d");

            migrationBuilder.AddColumn<string>(
                name: "ProgQuestionReports",
                table: "TestResults",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ProgQuestionReports",
                table: "TestResults");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05fc5ca0-8b3e-450d-bf9f-da5e7b9e525c", "5471f7e4-67b3-4418-8981-4fbb7dab921d", "Admin", "ADMIN" },
                    { "6debc715-5b9c-4684-8167-0d904d03b5d7", "4c912998-3da0-4d49-854e-0b418264ea52", "Student", "STUDENT" },
                    { "e8dc33fa-6b55-4345-91db-54d9f89aec1e", "6c75947e-aa5f-44d6-9579-8a6d7902504c", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastIP", "LastLogin", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eb23e58b-055e-4760-8652-12697ac1d89d", 0, "a8e6360a-8ca4-427f-af3c-0168fb9706b8", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@oenik.hu", true, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADMIN@OENIK.hu", "ADMIN", "AQAAAAEAACcQAAAAEKPxIPrY36sUWG2F7iu+/BgHt02sFbp9sEMQXwjBO/ZPe/KA/yb3TSRz+fxOp1GmrA==", null, false, "71eb09b3-06ab-4596-bbe7-2dffdab4f01c", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "05fc5ca0-8b3e-450d-bf9f-da5e7b9e525c", "eb23e58b-055e-4760-8652-12697ac1d89d" });
        }
    }
}
