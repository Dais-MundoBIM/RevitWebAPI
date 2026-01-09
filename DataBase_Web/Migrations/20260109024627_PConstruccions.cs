using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase_Web.Migrations
{
    /// <inheritdoc />
    public partial class PConstruccions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PConstruccions",
                columns: table => new
                {
                    ElementGUID = table.Column<string>(type: "text", nullable: false),
                    ElementID = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    ElementName = table.Column<string>(type: "text", nullable: false),
                    FechaProgramada = table.Column<string>(type: "text", nullable: false),
                    FechaEjecutada = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PConstruccions", x => x.ElementGUID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PConstruccions");
        }
    }
}
