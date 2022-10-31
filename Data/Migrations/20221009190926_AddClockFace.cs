using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddClockFace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClockFaceId",
                table: "Watches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ClockFace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClockFace", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ClockFace",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Blue" },
                    { 2, "White" },
                    { 3, "Black" },
                    { 4, "Green" }
                });

            migrationBuilder.UpdateData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClockFaceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClockFaceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClockFaceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Watches",
                keyColumn: "Id",
                keyValue: 4,
                column: "ClockFaceId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Watches_ClockFaceId",
                table: "Watches",
                column: "ClockFaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_ClockFace_ClockFaceId",
                table: "Watches",
                column: "ClockFaceId",
                principalTable: "ClockFace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watches_ClockFace_ClockFaceId",
                table: "Watches");

            migrationBuilder.DropTable(
                name: "ClockFace");

            migrationBuilder.DropIndex(
                name: "IX_Watches_ClockFaceId",
                table: "Watches");

            migrationBuilder.DropColumn(
                name: "ClockFaceId",
                table: "Watches");
        }
    }
}
