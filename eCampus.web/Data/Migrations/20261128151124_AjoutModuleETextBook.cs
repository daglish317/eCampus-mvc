using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCampus.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjoutModuleETextBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CahiersTexte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgrammeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Actif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CahiersTexte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CahiersTexte_Programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "Programmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntreesCahier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SeanceId = table.Column<int>(type: "INTEGER", nullable: false),
                    CahierTexteId = table.Column<int>(type: "INTEGER", nullable: false),
                    EnseignantId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContenuEnseigne = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    ActivitesRealisees = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    ActivitesPrevues = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Statut = table.Column<int>(type: "INTEGER", nullable: false),
                    DateSoumission = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntreesCahier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntreesCahier_CahiersTexte_CahierTexteId",
                        column: x => x.CahierTexteId,
                        principalTable: "CahiersTexte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntreesCahier_Enseignants_EnseignantId",
                        column: x => x.EnseignantId,
                        principalTable: "Enseignants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntreesCahier_Seances_SeanceId",
                        column: x => x.SeanceId,
                        principalTable: "Seances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DecisionsCahier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntreeCahierId = table.Column<int>(type: "INTEGER", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: false),
                    Decision = table.Column<int>(type: "INTEGER", nullable: false),
                    Commentaire = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    DateDecision = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecisionsCahier", x => x.Id);
                    table.CheckConstraint("CK_DecisionCahier_CommentaireRetour", "\"Decision\" = 0 OR (\"Commentaire\" IS NOT NULL AND TRIM(\"Commentaire\") <> '')");
                    table.ForeignKey(
                        name: "FK_DecisionsCahier_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DecisionsCahier_EntreesCahier_EntreeCahierId",
                        column: x => x.EntreeCahierId,
                        principalTable: "EntreesCahier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CahiersTexte_ProgrammeId",
                table: "CahiersTexte",
                column: "ProgrammeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DecisionsCahier_ApplicationUserId",
                table: "DecisionsCahier",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DecisionsCahier_EntreeCahierId",
                table: "DecisionsCahier",
                column: "EntreeCahierId");

            migrationBuilder.CreateIndex(
                name: "IX_EntreesCahier_CahierTexteId",
                table: "EntreesCahier",
                column: "CahierTexteId");

            migrationBuilder.CreateIndex(
                name: "IX_EntreesCahier_EnseignantId",
                table: "EntreesCahier",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_EntreesCahier_SeanceId",
                table: "EntreesCahier",
                column: "SeanceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntreesCahier_Statut",
                table: "EntreesCahier",
                column: "Statut");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DecisionsCahier");

            migrationBuilder.DropTable(
                name: "EntreesCahier");

            migrationBuilder.DropTable(
                name: "CahiersTexte");
        }
    }
}
