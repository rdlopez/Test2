using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[] { 1, "test1", 0 });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[] { 2, "test2", 1 });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[] { 3, "test3", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
