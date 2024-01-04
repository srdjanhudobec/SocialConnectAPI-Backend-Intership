using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialConnectAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAktivan = table.Column<bool>(type: "bit", nullable: false),
                    pratioci = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "objave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KreatorId = table.Column<int>(type: "int", nullable: false),
                    isArhivirana = table.Column<bool>(type: "bit", nullable: false),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_objave_korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "korisnici",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_objave_korisnici_KreatorId",
                        column: x => x.KreatorId,
                        principalTable: "korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pratioci",
                columns: table => new
                {
                    pratiocId = table.Column<int>(type: "int", nullable: false),
                    zapracenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pratioci", x => new { x.pratiocId, x.zapracenId });
                    table.ForeignKey(
                        name: "FK_pratioci_korisnici_pratiocId",
                        column: x => x.pratiocId,
                        principalTable: "korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pratioci_korisnici_zapracenId",
                        column: x => x.zapracenId,
                        principalTable: "korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "komentari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kreatorId = table.Column<int>(type: "int", nullable: false),
                    objavaId = table.Column<int>(type: "int", nullable: false),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_komentari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_komentari_korisnici_kreatorId",
                        column: x => x.kreatorId,
                        principalTable: "korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                  
                    table.ForeignKey(
                        name: "FK_komentari_objave_objavaId",
                        column: x => x.objavaId,
                        principalTable: "objave",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lajkovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kreatorId = table.Column<int>(type: "int", nullable: false),
                    objavaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lajkovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lajkovi_korisnici_kreatorId",
                        column: x => x.kreatorId,
                        principalTable: "korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lajkovi_objave_ObjavaId",
                        column: x => x.objavaId,
                        principalTable: "objave",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tagovi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    objavaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tagovi", x => x.id);
                    table.ForeignKey(
                        name: "FK_tagovi_objave_objavaId",
                        column: x => x.objavaId,
                        principalTable: "objave",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_komentari_kreatorId",
                table: "komentari",
                column: "kreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_komentari_objavaId",
                table: "komentari",
                column: "objavaId");

     

            migrationBuilder.CreateIndex(
                name: "IX_korisnici_Email",
                table: "korisnici",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lajkovi_kreatorId",
                table: "Lajkovi",
                column: "kreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lajkovi_objavaId",
                table: "Lajkovi",
                column: "objavaId");

            migrationBuilder.CreateIndex(
                name: "IX_objave_KorisnikId",
                table: "objave",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_objave_KreatorId",
                table: "objave",
                column: "KreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_pratioci_zapracenId",
                table: "pratioci",
                column: "zapracenId");

            migrationBuilder.CreateIndex(
                name: "IX_tagovi_objavaId",
                table: "tagovi",
                column: "objavaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "komentari");

            migrationBuilder.DropTable(
                name: "Lajkovi");

            migrationBuilder.DropTable(
                name: "pratioci");

            migrationBuilder.DropTable(
                name: "tagovi");

            migrationBuilder.DropTable(
                name: "objave");

            migrationBuilder.DropTable(
                name: "korisnici");
        }
    }
}
