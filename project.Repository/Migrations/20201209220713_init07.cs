using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Repository.Migrations
{
    public partial class init07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_AspNetUsers_CreatedById",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_AspNetUsers_Test_CreatedById",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_AspNetUsers_UserId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_CourseID",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_QuestionID",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_QuestionLabel_QuestionID",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_TestID",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_TestResultID",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTest_BaseEntity_CourseID",
                table: "CourseTest");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTest_BaseEntity_TestID",
                table: "CourseTest");

            migrationBuilder.DropForeignKey(
                name: "FK_TestProgQuestion_BaseEntity_ProgrammingQuestionID",
                table: "TestProgQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_TestProgQuestion_BaseEntity_TestID",
                table: "TestProgQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_BaseEntity_QuestionID",
                table: "TestQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_BaseEntity_TestID",
                table: "TestQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourse_BaseEntity_CourseID",
                table: "UserCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_CourseID",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_QuestionID",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_QuestionLabel_QuestionID",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_Test_CreatedById",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_TestID",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_TestResultID",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_UserId",
                table: "BaseEntity");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3754e317-69fc-433d-9405-43e58130fb50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99ea831c-ecee-4157-836a-ad151533572e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cf2e9aae-ba1e-4c65-99a0-c2561f81c68a", "dec9e78b-a544-4319-813c-9abadc06cfef" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf2e9aae-ba1e-4c65-99a0-c2561f81c68a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dec9e78b-a544-4319-813c-9abadc06cfef");

            migrationBuilder.DropColumn(
                name: "AnswerText",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "CorrectManually",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ExpectedOutput",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "FinishTime",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "IsCorrectionFinished",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "LabelText",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "OptimalNumberOfLines",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "PictureData",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "PictureExtensionType",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "PointResult",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ProgrammingQuestion_CreationTime",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "QuestionID",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "QuestionLabel_QuestionID",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "QuestionType1",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Question_CorrectAnswer",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Question_CorrectManually",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Question_CreationTime",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Question_IsShared",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Question_MaxPoints",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Question_PictureData",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Question_PictureExtensionType",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Question_Text",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Question_Title",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ReferenceComplexityLevel",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ReferenceRuntime",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "TestID",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "TestResultID",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Test_CreatedById",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Test_CreationTime",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Test_IsShared",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Test_MaxPoints",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Test_Title",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BaseEntity");

            migrationBuilder.RenameTable(
                name: "BaseEntity",
                newName: "Tests");

            migrationBuilder.RenameIndex(
                name: "IX_BaseEntity_CreatedById",
                table: "Tests",
                newName: "IX_Tests_CreatedById");

            migrationBuilder.AlterColumn<double>(
                name: "MaxPoints",
                table: "Tests",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsShared",
                table: "Tests",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsLateSubmissionAllowed",
                table: "Tests",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Tests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "AllowedTakeLength",
                table: "Tests",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tests",
                table: "Tests",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsShared = table.Column<bool>(type: "bit", nullable: false),
                    CorrectManually = table.Column<bool>(type: "bit", nullable: false),
                    QuestionType = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxPoints = table.Column<double>(type: "float", nullable: false),
                    PictureExtensionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PictureData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptimalNumberOfLines = table.Column<int>(type: "int", nullable: true),
                    ReferenceComplexityLevel = table.Column<int>(type: "int", nullable: true),
                    ReferenceRuntime = table.Column<TimeSpan>(type: "time", nullable: true),
                    ExpectedOutput = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Questions_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestResults",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TestID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CourseID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointResult = table.Column<double>(type: "float", nullable: false),
                    IsCorrectionFinished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResults", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TestResults_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestResults_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestResults_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionLabels",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LabelText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionLabels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuestionLabels_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectManually = table.Column<bool>(type: "bit", nullable: false),
                    TestResultID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_TestResults_TestResultID",
                        column: x => x.TestResultID,
                        principalTable: "TestResults",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionID",
                table: "Answers",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TestResultID",
                table: "Answers",
                column: "TestResultID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionLabels_QuestionID",
                table: "QuestionLabels",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CreatedById",
                table: "Questions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_CourseID",
                table: "TestResults",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_TestID",
                table: "TestResults",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_UserId",
                table: "TestResults",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_CreatedById",
                table: "Tests",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourse_Courses_CourseID",
                table: "UserCourse",
                column: "CourseID",
                principalTable: "Courses",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_CreatedById",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourse_Courses_CourseID",
                table: "UserCourse");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "QuestionLabels");

            migrationBuilder.DropTable(
                name: "TestResults");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tests",
                table: "Tests");

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

            migrationBuilder.RenameTable(
                name: "Tests",
                newName: "BaseEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_CreatedById",
                table: "BaseEntity",
                newName: "IX_BaseEntity_CreatedById");

            migrationBuilder.AlterColumn<double>(
                name: "MaxPoints",
                table: "BaseEntity",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "IsShared",
                table: "BaseEntity",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsLateSubmissionAllowed",
                table: "BaseEntity",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "BaseEntity",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "AllowedTakeLength",
                table: "BaseEntity",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<string>(
                name: "AnswerText",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CorrectManually",
                table: "BaseEntity",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseID",
                table: "BaseEntity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExpectedOutput",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishTime",
                table: "BaseEntity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrectionFinished",
                table: "BaseEntity",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LabelText",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BaseEntity",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OptimalNumberOfLines",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PictureData",
                table: "BaseEntity",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureExtensionType",
                table: "BaseEntity",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PointResult",
                table: "BaseEntity",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProgrammingQuestion_CreationTime",
                table: "BaseEntity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionID",
                table: "BaseEntity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionLabel_QuestionID",
                table: "BaseEntity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionType",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionType1",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question_CorrectAnswer",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Question_CorrectManually",
                table: "BaseEntity",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Question_CreationTime",
                table: "BaseEntity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Question_IsShared",
                table: "BaseEntity",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Question_MaxPoints",
                table: "BaseEntity",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Question_PictureData",
                table: "BaseEntity",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question_PictureExtensionType",
                table: "BaseEntity",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question_Text",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question_Title",
                table: "BaseEntity",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReferenceComplexityLevel",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ReferenceRuntime",
                table: "BaseEntity",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "BaseEntity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestID",
                table: "BaseEntity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestResultID",
                table: "BaseEntity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Test_CreatedById",
                table: "BaseEntity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Test_CreationTime",
                table: "BaseEntity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Test_IsShared",
                table: "BaseEntity",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Test_MaxPoints",
                table: "BaseEntity",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Test_Title",
                table: "BaseEntity",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BaseEntity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity",
                column: "ID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cf2e9aae-ba1e-4c65-99a0-c2561f81c68a", "5d324045-1f85-4e40-895a-f5ce6437e025", "Admin", "ADMIN" },
                    { "99ea831c-ecee-4157-836a-ad151533572e", "8814ecd2-9845-45b5-af28-7367c57e0985", "Student", "STUDENT" },
                    { "3754e317-69fc-433d-9405-43e58130fb50", "6b51dc0b-4474-408f-b6fd-3e84907d3739", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastIP", "LastLogin", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dec9e78b-a544-4319-813c-9abadc06cfef", 0, "d4ca0e68-3e7c-4a83-9daf-89d5ed931146", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@oenik.hu", true, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADMIN@OENIK.hu", "ADMIN", "AQAAAAEAACcQAAAAEA+Og6ZONsvfNBqag/pUwmPgAY7vvOegXYNv8IbCvZ9sA9Z8EyLr0wtqmlOWf+mcmw==", null, false, "788d8d77-e6c7-4076-b909-ff407d63043d", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cf2e9aae-ba1e-4c65-99a0-c2561f81c68a", "dec9e78b-a544-4319-813c-9abadc06cfef" });

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_CourseID",
                table: "BaseEntity",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_QuestionID",
                table: "BaseEntity",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_QuestionLabel_QuestionID",
                table: "BaseEntity",
                column: "QuestionLabel_QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Test_CreatedById",
                table: "BaseEntity",
                column: "Test_CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_TestID",
                table: "BaseEntity",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_TestResultID",
                table: "BaseEntity",
                column: "TestResultID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_UserId",
                table: "BaseEntity",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_AspNetUsers_CreatedById",
                table: "BaseEntity",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_AspNetUsers_Test_CreatedById",
                table: "BaseEntity",
                column: "Test_CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_AspNetUsers_UserId",
                table: "BaseEntity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_CourseID",
                table: "BaseEntity",
                column: "CourseID",
                principalTable: "BaseEntity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_QuestionID",
                table: "BaseEntity",
                column: "QuestionID",
                principalTable: "BaseEntity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_QuestionLabel_QuestionID",
                table: "BaseEntity",
                column: "QuestionLabel_QuestionID",
                principalTable: "BaseEntity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_TestID",
                table: "BaseEntity",
                column: "TestID",
                principalTable: "BaseEntity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_TestResultID",
                table: "BaseEntity",
                column: "TestResultID",
                principalTable: "BaseEntity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTest_BaseEntity_CourseID",
                table: "CourseTest",
                column: "CourseID",
                principalTable: "BaseEntity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTest_BaseEntity_TestID",
                table: "CourseTest",
                column: "TestID",
                principalTable: "BaseEntity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestProgQuestion_BaseEntity_ProgrammingQuestionID",
                table: "TestProgQuestion",
                column: "ProgrammingQuestionID",
                principalTable: "BaseEntity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestProgQuestion_BaseEntity_TestID",
                table: "TestProgQuestion",
                column: "TestID",
                principalTable: "BaseEntity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestion_BaseEntity_QuestionID",
                table: "TestQuestion",
                column: "QuestionID",
                principalTable: "BaseEntity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestion_BaseEntity_TestID",
                table: "TestQuestion",
                column: "TestID",
                principalTable: "BaseEntity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourse_BaseEntity_CourseID",
                table: "UserCourse",
                column: "CourseID",
                principalTable: "BaseEntity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
