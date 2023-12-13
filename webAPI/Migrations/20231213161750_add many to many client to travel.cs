using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations
{
    /// <inheritdoc />
    public partial class addmanytomanyclienttotravel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Travel_TravelId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_TravelId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "TravelId",
                table: "Client");

            migrationBuilder.CreateTable(
                name: "ClientTravel",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    TravelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTravel", x => new { x.ClientId, x.TravelsId });
                    table.ForeignKey(
                        name: "FK_ClientTravel_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientTravel_Travel_TravelsId",
                        column: x => x.TravelsId,
                        principalTable: "Travel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTravel_TravelsId",
                table: "ClientTravel",
                column: "TravelsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientTravel");

            migrationBuilder.AddColumn<int>(
                name: "TravelId",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_TravelId",
                table: "Client",
                column: "TravelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Travel_TravelId",
                table: "Client",
                column: "TravelId",
                principalTable: "Travel",
                principalColumn: "Id");
        }
    }
}
