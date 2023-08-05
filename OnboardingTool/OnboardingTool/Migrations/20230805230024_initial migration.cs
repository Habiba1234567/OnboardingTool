using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingTool.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Course_code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Course_code);
                });

            migrationBuilder.CreateTable(
                name: "logs",
                columns: table => new
                {
                    time_of_occurance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.time_of_occurance);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    type_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_buddy = table.Column<bool>(type: "bit", nullable: false),
                    new_employee = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.type_code);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role_id = table.Column<int>(type: "int", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    phoneNum = table.Column<int>(type: "int", nullable: false),
                    job_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enrollment_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Courses",
                columns: table => new
                {
                    Course_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Courses", x => x.Course_code);
                    table.ForeignKey(
                        name: "FK_User_Courses_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_roles",
                columns: table => new
                {
                    type_code = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_roles", x => new { x.type_code, x.user_id });
                    table.ForeignKey(
                        name: "FK_User_roles_Roles_type_code",
                        column: x => x.type_code,
                        principalTable: "Roles",
                        principalColumn: "type_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_roles_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Userslog",
                columns: table => new
                {
                    logstime_of_occurance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userslog", x => new { x.logstime_of_occurance, x.usersId });
                    table.ForeignKey(
                        name: "FK_Userslog_Users_usersId",
                        column: x => x.usersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Userslog_logs_logstime_of_occurance",
                        column: x => x.logstime_of_occurance,
                        principalTable: "logs",
                        principalColumn: "time_of_occurance",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursesUser_courses",
                columns: table => new
                {
                    coursesCourse_code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_coursesCourse_code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesUser_courses", x => new { x.coursesCourse_code, x.user_coursesCourse_code });
                    table.ForeignKey(
                        name: "FK_CoursesUser_courses_Courses_coursesCourse_code",
                        column: x => x.coursesCourse_code,
                        principalTable: "Courses",
                        principalColumn: "Course_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesUser_courses_User_Courses_user_coursesCourse_code",
                        column: x => x.user_coursesCourse_code,
                        principalTable: "User_Courses",
                        principalColumn: "Course_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesUser_courses_user_coursesCourse_code",
                table: "CoursesUser_courses",
                column: "user_coursesCourse_code");

            migrationBuilder.CreateIndex(
                name: "IX_User_Courses_UsersId",
                table: "User_Courses",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_User_roles_UsersId",
                table: "User_roles",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Userslog_usersId",
                table: "Userslog",
                column: "usersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesUser_courses");

            migrationBuilder.DropTable(
                name: "User_roles");

            migrationBuilder.DropTable(
                name: "Userslog");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "User_Courses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "logs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
