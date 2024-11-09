using Microsoft.EntityFrameworkCore.Migrations;

namespace Mislibros_JLAR.Migrations
{
    public partial class PublisherAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PublisherId1",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId1",
                table: "Books",
                column: "PublisherId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publisher_PublisherId1",
                table: "Books",
                column: "PublisherId1",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publisher_PublisherId1",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_Books_PublisherId1",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublisherId1",
                table: "Books");
        }
    }
}
