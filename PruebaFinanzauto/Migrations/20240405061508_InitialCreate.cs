using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaFinanzauto.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Created_at", "Description", "Name", "Updated_at" },
                values: new object[] { 1, new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6746), "Description for Course A", "Course A", new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6746) });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Created_at", "Description", "Name", "Updated_at" },
                values: new object[] { 2, new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6747), "Description for Course B", "Course B", new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6748) });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CourseId", "Created_at", "Email", "EnrollmentDate", "LastName", "Name", "PhoneNumber", "Updated_at" },
                values: new object[,]
                {
                    { 1, "Cr23 #45-5", 1, new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6635), "prueba@gmail.com", new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6634), "Till", "Maria", "3155408709", new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6635) },
                    { 2, "Edificio Casa Blanca apto 208", 1, new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6638), "prueba2@gmail.com", new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6637), "Till", "Julia", "3155988709", new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6638) },
                    { 3, "La Castellana Cr 12 #45", 2, new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6640), "prueba3@gmail.com", new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6640), "Henao", "Pablo", "3175988709", new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6640) },
                    { 4, "La Castellana Cr 12 #45", 2, new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6642), "prueba4@gmail.com", new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6642), "Hidalgo", "Juan", "3255988709", new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6642) }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CourseId", "Created_at", "Description", "Name", "Updated_at" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6731), "Materia basada en hechos cientificos", "Ciencias Naturales", new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6732) },
                    { 2, 1, new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6733), "Materia basada en numeros", "Matematicas", new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6734) },
                    { 3, 2, new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6735), "Materia basada en la literatura espaniola", "Espaniol", new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6735) },
                    { 4, 2, new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6736), "Materia basada en la historia y hechos reales", "Sociales", new DateTime(2024, 4, 5, 1, 15, 8, 725, DateTimeKind.Local).AddTicks(6736) }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Created_at", "StudentId", "SubjectId", "Updated_at", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.0 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.0 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.0 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92.0 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88.0 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 91.0 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.0 },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CourseId",
                table: "Subjects",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
