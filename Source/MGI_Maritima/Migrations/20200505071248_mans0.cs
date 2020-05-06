using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MGI_Maritima.Migrations
{
    public partial class mans0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loginvenatario",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idubicacion = table.Column<int>(nullable: false),
                    idarticulo = table.Column<int>(nullable: false),
                    detalle = table.Column<string>(nullable: true),
                    fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loginvenatario", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loginvenatario");
        }
    }
}
