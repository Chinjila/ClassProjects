using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExtendingEF.Migrations
{
    /// <inheritdoc />
    public partial class AddWriter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    WriterID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    JoinedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.WriterID);
                });

            migrationBuilder.CreateTable(
                name: "BlogWriter",
                columns: table => new
                {
                    BlogsBlogId = table.Column<int>(type: "INTEGER", nullable: false),
                    WritersWriterID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogWriter", x => new { x.BlogsBlogId, x.WritersWriterID });
                    table.ForeignKey(
                        name: "FK_BlogWriter_Blogs_BlogsBlogId",
                        column: x => x.BlogsBlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogWriter_Writers_WritersWriterID",
                        column: x => x.WritersWriterID,
                        principalTable: "Writers",
                        principalColumn: "WriterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogWriter_WritersWriterID",
                table: "BlogWriter",
                column: "WritersWriterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogWriter");

            migrationBuilder.DropTable(
                name: "Writers");
        }
    }
}
