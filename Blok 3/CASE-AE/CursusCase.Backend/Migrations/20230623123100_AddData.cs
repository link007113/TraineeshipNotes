using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursusCase.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                  table: "Courses",
                  columns: new[] { "Title", "Code", "DurationInDays" },
                  values: new object[,]
                  {
            { "C# Programmeren", "CNETIN", 5 },
            { "Java Persistence API", "JPA", 2 }
                  });

            migrationBuilder.InsertData(
                table: "CourseInstances",
                columns: new[] { "CursusId", "StartDate" },
                values: new object[,]
                {
            { 1, new DateTime(2018, 10, 8) },
            { 1, new DateTime(2018, 10, 15) },
            { 2, new DateTime(2018, 10, 15) },
            { 2, new DateTime(2018, 10, 8) }
                });

            migrationBuilder.InsertData(
             table: "Students",
             columns: new[] { "Id", "FirstName", "LastName" },
             values: new object[,]
             {
                    { 1, "John", "Coder" },
                    { 2, "Emma", "Developer" },
                    { 3, "Lucas", "Hacker" },
                    { 4, "Sophia", "Scripter" },
                    { 5, "Max", "Debugger" },
                    { 6, "Angelica", "Programmer" },
                    { 7, "Leo", "Compiler" },
                    { 8, "Ava", "Bugfixer" },
                    { 9, "Liam", "Algorithm" },
                    { 10, "Isabelle", "Syntax" },
                    { 11, "Noah", "Loop" },
                    { 12, "Mia", "Variable" },
                    { 13, "James", "Stack" },
                    { 14, "Charlotte", "Queue" },
                    { 15, "Benjamin", "Pointer" },
                    { 16, "Amelia", "Bitwise" },
                    { 17, "Henry", "Recursive" },
                    { 18, "Evelyn", "Function" },
                    { 19, "Alexander", "Object" },
                    { 20, "Harper", "Class" },
                    { 21, "Daniel", "Interface" },
                    { 22, "Abigail", "Inheritance" },
                    { 23, "Matthew", "Polymorphism" },
                    { 24, "Emily", "Encapsulation" }
             }
         );

            migrationBuilder.InsertData(
                table: "CourseInstanceStudent",
                columns: new[] { "CourseInstancesId", "StudentsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 2, 13 },
                    { 2, 14 },
                    { 2, 15 },
                    { 2, 16 },
                    { 2, 17 },
                    { 2, 18 },
                    { 2, 19 },
                    { 2, 20 },
                    { 2, 21 },
                    { 2, 22 },
                    { 2, 23 },
                    { 2, 24 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 4, 13 },
                    { 4, 14 },
                    { 4, 15 },
                    { 4, 16 },
                    { 4, 17 },
                    { 4, 18 },
                    { 4, 19 },
                    { 4, 20 },
                    { 4, 21 },
                    { 4, 22 },
                    { 4, 23 },
                    { 4, 24 }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}