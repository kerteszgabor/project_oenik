using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Repository.Migrations
{
    public partial class AddIsClosedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTest_Courses_CourseID",
                table: "CourseTest");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTest_Tests_TestID",
                table: "CourseTest");

            migrationBuilder.DropForeignKey(
                name: "FK_TestProgQuestion_Questions_ProgrammingQuestionID",
                table: "TestProgQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_TestProgQuestion_Tests_TestID",
                table: "TestProgQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_Questions_QuestionID",
                table: "TestQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_Tests_TestID",
                table: "TestQuestion");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "TestResults",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTest_Courses_CourseID",
                table: "CourseTest",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTest_Tests_TestID",
                table: "CourseTest",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestProgQuestion_Questions_ProgrammingQuestionID",
                table: "TestProgQuestion",
                column: "ProgrammingQuestionID",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestProgQuestion_Tests_TestID",
                table: "TestProgQuestion",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestion_Questions_QuestionID",
                table: "TestQuestion",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestion_Tests_TestID",
                table: "TestQuestion",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTest_Courses_CourseID",
                table: "CourseTest");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTest_Tests_TestID",
                table: "CourseTest");

            migrationBuilder.DropForeignKey(
                name: "FK_TestProgQuestion_Questions_ProgrammingQuestionID",
                table: "TestProgQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_TestProgQuestion_Tests_TestID",
                table: "TestProgQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_Questions_QuestionID",
                table: "TestQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_Tests_TestID",
                table: "TestQuestion");

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

            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "TestResults");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTest_Courses_CourseID",
                table: "CourseTest",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTest_Tests_TestID",
                table: "CourseTest",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestProgQuestion_Questions_ProgrammingQuestionID",
                table: "TestProgQuestion",
                column: "ProgrammingQuestionID",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestProgQuestion_Tests_TestID",
                table: "TestProgQuestion",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestion_Questions_QuestionID",
                table: "TestQuestion",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestion_Tests_TestID",
                table: "TestQuestion",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
