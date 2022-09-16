using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    public partial class Initialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb66002"), null, "Actividades personales", 50 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb660be"), null, "Actividades pendientes", 20 });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreatedAt", "Description", "Priority", "Title" },
                values: new object[] { new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb66023"), new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb660be"), new DateTime(2022, 9, 14, 14, 1, 53, 263, DateTimeKind.Local).AddTicks(72), null, 1, "Pago de servicios" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreatedAt", "Description", "Priority", "Title" },
                values: new object[] { new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb66024"), new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb66002"), new DateTime(2022, 9, 14, 14, 1, 53, 263, DateTimeKind.Local).AddTicks(169), null, 0, "Terminar tareas" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb66023"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb66024"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb66002"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("824e8ee9-f83d-42dc-9320-8d1d0cb660be"));
        }
    }
}
