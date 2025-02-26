using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class createss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_AspNetUsers_UserId1",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_AspNetUsers_UserId1",
                table: "PaymentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_SellerId1",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_SellerId1",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_PaymentHistories_UserId1",
                table: "PaymentHistories");

            migrationBuilder.DropIndex(
                name: "IX_Bids_UserId1",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "SellerId1",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Bids");

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                table: "Vehicles",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PaymentHistories",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bids",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_SellerId",
                table: "Vehicles",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistories_UserId",
                table: "PaymentHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_UserId",
                table: "Bids",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_AspNetUsers_UserId",
                table: "Bids",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_AspNetUsers_UserId",
                table: "PaymentHistories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_SellerId",
                table: "Vehicles",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_AspNetUsers_UserId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_AspNetUsers_UserId",
                table: "PaymentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_SellerId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_SellerId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_PaymentHistories_UserId",
                table: "PaymentHistories");

            migrationBuilder.DropIndex(
                name: "IX_Bids_UserId",
                table: "Bids");

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SellerId1",
                table: "Vehicles",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PaymentHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "PaymentHistories",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bids",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Bids",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_SellerId1",
                table: "Vehicles",
                column: "SellerId1");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistories_UserId1",
                table: "PaymentHistories",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_UserId1",
                table: "Bids",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_AspNetUsers_UserId1",
                table: "Bids",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_AspNetUsers_UserId1",
                table: "PaymentHistories",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_SellerId1",
                table: "Vehicles",
                column: "SellerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
