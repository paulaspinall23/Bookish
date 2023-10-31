using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookish.Migrations
{
    /// <inheritdoc />
    public partial class CorrectLoanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Loans_LoansId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "LoansUser");

            migrationBuilder.RenameColumn(
                name: "LoansId",
                table: "Books",
                newName: "LoanId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_LoansId",
                table: "Books",
                newName: "IX_Books_LoanId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Loans",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                table: "Loans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Loans_LoanId",
                table: "Books",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_UserId",
                table: "Loans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Loans_LoanId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_UserId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_UserId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "LoanId",
                table: "Books",
                newName: "LoansId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_LoanId",
                table: "Books",
                newName: "IX_Books_LoansId");

            migrationBuilder.CreateTable(
                name: "LoansUser",
                columns: table => new
                {
                    LoansId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoansUser", x => new { x.LoansId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_LoansUser_Loans_LoansId",
                        column: x => x.LoansId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoansUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoansUser_UsersId",
                table: "LoansUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Loans_LoansId",
                table: "Books",
                column: "LoansId",
                principalTable: "Loans",
                principalColumn: "Id");
        }
    }
}
