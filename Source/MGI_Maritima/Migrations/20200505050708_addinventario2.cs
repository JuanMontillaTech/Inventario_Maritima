using Microsoft.EntityFrameworkCore.Migrations;

namespace MGI_Maritima.Migrations
{
    public partial class addinventario2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invenatrio",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idalmacen = table.Column<int>(nullable: false),
                    idarticulo = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invenatrio", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invenatrio");
        }
    }
}
