using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projet.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(nullable: false),
                    prenom = table.Column<string>(nullable: false),
                    username = table.Column<string>(nullable: false),
                    mdp = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    photo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enseignants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(nullable: false),
                    prenom = table.Column<string>(nullable: false),
                    username = table.Column<string>(nullable: false),
                    mdp = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    telephone = table.Column<string>(nullable: false),
                    photo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filieres",
                columns: table => new
                {
                    id_fil = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nom_fil = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filieres", x => x.id_fil);
                });

            migrationBuilder.CreateTable(
                name: "Niveaus",
                columns: table => new
                {
                    id_niv = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nom_niv = table.Column<string>(nullable: false),
                    id_fil = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveaus", x => x.id_niv);
                    table.ForeignKey(
                        name: "FK_Niveaus_Filieres_id_fil",
                        column: x => x.id_fil,
                        principalTable: "Filieres",
                        principalColumn: "id_fil",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    id_mod = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nom_mod = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: true),
                    id_niv = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.id_mod);
                    table.ForeignKey(
                        name: "FK_Modules_Enseignants_Id",
                        column: x => x.Id,
                        principalTable: "Enseignants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Modules_Niveaus_id_niv",
                        column: x => x.id_niv,
                        principalTable: "Niveaus",
                        principalColumn: "id_niv",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chapitres",
                columns: table => new
                {
                    id_chap = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(nullable: false),
                    contenu = table.Column<string>(nullable: false),
                    date_depot = table.Column<string>(nullable: false),
                    responsable = table.Column<string>(nullable: false),
                    id_mod = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chapitres", x => x.id_chap);
                    table.ForeignKey(
                        name: "FK_chapitres_Modules_id_mod",
                        column: x => x.id_mod,
                        principalTable: "Modules",
                        principalColumn: "id_mod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chapitres_id_mod",
                table: "chapitres",
                column: "id_mod");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_Id",
                table: "Modules",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_id_niv",
                table: "Modules",
                column: "id_niv");

            migrationBuilder.CreateIndex(
                name: "IX_Niveaus_id_fil",
                table: "Niveaus",
                column: "id_fil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "chapitres");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Enseignants");

            migrationBuilder.DropTable(
                name: "Niveaus");

            migrationBuilder.DropTable(
                name: "Filieres");
        }
    }
}
