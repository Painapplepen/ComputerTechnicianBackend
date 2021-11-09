using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerTechnicianBackend.Data.EF.SQL.Migrations
{
    public partial class UpdatedBasketTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Users_Amount",
                table: "Baskets");

            migrationBuilder.DropTable(
                name: "UsersView");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_Amount",
                table: "Baskets");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Baskets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Baskets");

            migrationBuilder.CreateTable(
                name: "UsersView",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasketSize = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersView", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_Amount",
                table: "Baskets",
                column: "Amount",
                unique: true,
                filter: "[Amount] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Users_Amount",
                table: "Baskets",
                column: "Amount",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
