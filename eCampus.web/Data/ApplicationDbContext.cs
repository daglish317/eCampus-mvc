using eCampus.web.Models.EAcademie;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eCampus.web.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // === Module e-Académie ===
        public DbSet<AnneeAcademique> AnneesAcademiques => Set<AnneeAcademique>();
        public DbSet<Semestre> Semestres => Set<Semestre>();
        public DbSet<Niveau> Niveaux => Set<Niveau>();
        public DbSet<Classe> Classes => Set<Classe>();
        public DbSet<Etudiant> Etudiants => Set<Etudiant>();
        public DbSet<Inscription> Inscriptions => Set<Inscription>();
        public DbSet<Matiere> Matieres => Set<Matiere>();
        public DbSet<Programme> Programmes => Set<Programme>();
        public DbSet<Enseignant> Enseignants => Set<Enseignant>();
        public DbSet<Affectation> Affectations => Set<Affectation>();
        public DbSet<ProgrammeHebdomadaire> ProgrammesHebdomadaires => Set<ProgrammeHebdomadaire>();
        public DbSet<Seance> Seances => Set<Seance>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // RG01.1 : une seule année active à la fois → index unique partiel
            builder.Entity<AnneeAcademique>()
                .HasIndex(a => a.EstActive)
                .HasFilter("\"EstActive\" = 1")
                .IsUnique();

            // RG06.1 : matricule étudiant unique
            builder.Entity<Etudiant>()
                .HasIndex(e => e.Matricule)
                .IsUnique();

            // RG11.9 (plus tard) : un seul enregistrement de présence par séance/étudiant
            // on le fera à l'étape e-Présence

            // Relation 1-1 : Enseignant ↔ ApplicationUser
            builder.Entity<Enseignant>()
                .HasOne(e => e.ApplicationUser)
                .WithOne()
                .HasForeignKey<Enseignant>(e => e.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

                        // Charge automatiquement toutes les configurations EF du projet
            // (chaque module dépose ses fichiers dans Data/Configurations/)
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}