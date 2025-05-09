using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoSecurityX.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MOTO",
                columns: table => new
                {
                    ID_MOTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PLACA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MODELO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SITUACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOTO", x => x.ID_MOTO);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MOTO");
        }
    }
}
