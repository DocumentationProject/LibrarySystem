using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedIsAvailableforBookEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTransfers_Users_UserId",
                table: "BookTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBalances_Users_UserId",
                table: "UserBalances");

            migrationBuilder.DropTable(
                name: "UserUserCategory");

            migrationBuilder.DropIndex(
                name: "IX_UserBalances_UserId",
                table: "UserBalances");

            migrationBuilder.DropIndex(
                name: "IX_BookTransfers_UserId",
                table: "BookTransfers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "BookTransfers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserCategoryEntityUserEntity",
                columns: table => new
                {
                    UserCategoriesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategoryEntityUserEntity", x => new { x.UserCategoriesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserCategoryEntityUserEntity_UserCategories_UserCategoriesId",
                        column: x => x.UserCategoriesId,
                        principalTable: "UserCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCategoryEntityUserEntity_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookTransfers_UserEntityId",
                table: "BookTransfers",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategoryEntityUserEntity_UsersId",
                table: "UserCategoryEntityUserEntity",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTransfers_Users_UserEntityId",
                table: "BookTransfers",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserBalances_Id",
                table: "Users",
                column: "Id",
                principalTable: "UserBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTransfers_Users_UserEntityId",
                table: "BookTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserBalances_Id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserCategoryEntityUserEntity");

            migrationBuilder.DropIndex(
                name: "IX_BookTransfers_UserEntityId",
                table: "BookTransfers");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "BookTransfers");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "UserUserCategory",
                columns: table => new
                {
                    UserCategoriesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserCategory", x => new { x.UserCategoriesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserUserCategory_UserCategories_UserCategoriesId",
                        column: x => x.UserCategoriesId,
                        principalTable: "UserCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUserCategory_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBalances_UserId",
                table: "UserBalances",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookTransfers_UserId",
                table: "BookTransfers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserCategory_UsersId",
                table: "UserUserCategory",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTransfers_Users_UserId",
                table: "BookTransfers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBalances_Users_UserId",
                table: "UserBalances",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
