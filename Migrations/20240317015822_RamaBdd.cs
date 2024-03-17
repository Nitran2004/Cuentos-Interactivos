using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecureAssetManager.Migrations
{
    public partial class RamaBdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atorado",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoControl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Efectividad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atorado", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Codigo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoControl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Efectividad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codigo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mapa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoControl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Efectividad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mapa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rusa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoControl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Efectividad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rusa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Victoria",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoControl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Efectividad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Victoria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoControl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Efectividad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atorado");

            migrationBuilder.DropTable(
                name: "Codigo");

            migrationBuilder.DropTable(
                name: "Mapa");

            migrationBuilder.DropTable(
                name: "Rusa");

            migrationBuilder.DropTable(
                name: "Victoria");

            migrationBuilder.DropTable(
                name: "Video");
        }
    }
}
