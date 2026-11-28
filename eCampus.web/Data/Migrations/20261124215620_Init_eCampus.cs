using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCampus.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init_eCampus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnneesAcademiques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    DateDebut = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateFin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnneesAcademiques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enseignants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enseignants_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricule = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matieres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matieres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Niveaux",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveaux", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semestres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    DateDebut = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateFin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AnneeAcademiqueId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semestres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semestres_AnneesAcademiques_AnneeAcademiqueId",
                        column: x => x.AnneeAcademiqueId,
                        principalTable: "AnneesAcademiques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    NiveauId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Niveaux_NiveauId",
                        column: x => x.NiveauId,
                        principalTable: "Niveaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammesHebdomadaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnneeAcademiqueId = table.Column<int>(type: "INTEGER", nullable: false),
                    NiveauId = table.Column<int>(type: "INTEGER", nullable: false),
                    CheminFichier = table.Column<string>(type: "TEXT", nullable: false),
                    DateImport = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstPubliee = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammesHebdomadaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammesHebdomadaires_AnneesAcademiques_AnneeAcademiqueId",
                        column: x => x.AnneeAcademiqueId,
                        principalTable: "AnneesAcademiques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgrammesHebdomadaires_Niveaux_NiveauId",
                        column: x => x.NiveauId,
                        principalTable: "Niveaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MatiereId = table.Column<int>(type: "INTEGER", nullable: false),
                    NiveauId = table.Column<int>(type: "INTEGER", nullable: false),
                    SemestreId = table.Column<int>(type: "INTEGER", nullable: false),
                    AnneeAcademiqueId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateEffet = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstActif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programmes_AnneesAcademiques_AnneeAcademiqueId",
                        column: x => x.AnneeAcademiqueId,
                        principalTable: "AnneesAcademiques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Programmes_Matieres_MatiereId",
                        column: x => x.MatiereId,
                        principalTable: "Matieres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Programmes_Niveaux_NiveauId",
                        column: x => x.NiveauId,
                        principalTable: "Niveaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Programmes_Semestres_SemestreId",
                        column: x => x.SemestreId,
                        principalTable: "Semestres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EtudiantId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClasseId = table.Column<int>(type: "INTEGER", nullable: false),
                    AnneeAcademiqueId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateInscription = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscriptions_AnneesAcademiques_AnneeAcademiqueId",
                        column: x => x.AnneeAcademiqueId,
                        principalTable: "AnneesAcademiques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Classes_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Etudiants_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Affectations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EnseignantId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProgrammeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateFin = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affectations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Affectations_Enseignants_EnseignantId",
                        column: x => x.EnseignantId,
                        principalTable: "Enseignants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Affectations_Programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "Programmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgrammeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HeureDebut = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Duree = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Salle = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    EnseignantId = table.Column<int>(type: "INTEGER", nullable: false),
                    EstPubliee = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProgrammeHebdomadaireId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seances_Enseignants_EnseignantId",
                        column: x => x.EnseignantId,
                        principalTable: "Enseignants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seances_ProgrammesHebdomadaires_ProgrammeHebdomadaireId",
                        column: x => x.ProgrammeHebdomadaireId,
                        principalTable: "ProgrammesHebdomadaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seances_Programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "Programmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Affectations_EnseignantId",
                table: "Affectations",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_Affectations_ProgrammeId",
                table: "Affectations",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnneesAcademiques_EstActive",
                table: "AnneesAcademiques",
                column: "EstActive",
                unique: true,
                filter: "\"EstActive\" = 1");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_NiveauId",
                table: "Classes",
                column: "NiveauId");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignants_ApplicationUserId",
                table: "Enseignants",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_Matricule",
                table: "Etudiants",
                column: "Matricule",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_AnneeAcademiqueId",
                table: "Inscriptions",
                column: "AnneeAcademiqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_ClasseId",
                table: "Inscriptions",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_EtudiantId",
                table: "Inscriptions",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_Programmes_AnneeAcademiqueId",
                table: "Programmes",
                column: "AnneeAcademiqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Programmes_MatiereId",
                table: "Programmes",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_Programmes_NiveauId",
                table: "Programmes",
                column: "NiveauId");

            migrationBuilder.CreateIndex(
                name: "IX_Programmes_SemestreId",
                table: "Programmes",
                column: "SemestreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammesHebdomadaires_AnneeAcademiqueId",
                table: "ProgrammesHebdomadaires",
                column: "AnneeAcademiqueId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammesHebdomadaires_NiveauId",
                table: "ProgrammesHebdomadaires",
                column: "NiveauId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_EnseignantId",
                table: "Seances",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_ProgrammeHebdomadaireId",
                table: "Seances",
                column: "ProgrammeHebdomadaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_ProgrammeId",
                table: "Seances",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_Semestres_AnneeAcademiqueId",
                table: "Semestres",
                column: "AnneeAcademiqueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Affectations");

            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Etudiants");

            migrationBuilder.DropTable(
                name: "Enseignants");

            migrationBuilder.DropTable(
                name: "ProgrammesHebdomadaires");

            migrationBuilder.DropTable(
                name: "Programmes");

            migrationBuilder.DropTable(
                name: "Matieres");

            migrationBuilder.DropTable(
                name: "Niveaux");

            migrationBuilder.DropTable(
                name: "Semestres");

            migrationBuilder.DropTable(
                name: "AnneesAcademiques");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "AspNetUsers");
        }
    }
}
