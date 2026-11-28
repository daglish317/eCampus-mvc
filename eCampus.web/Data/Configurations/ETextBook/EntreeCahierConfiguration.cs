using eCampus.web.Models.ETextBook;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCampus.web.Data.Configurations.ETextBook;

public class EntreeCahierConfiguration : IEntityTypeConfiguration<EntreeCahier>
{
    public void Configure(EntityTypeBuilder<EntreeCahier> builder)
    {
        // 1. Nom de la table
        builder.ToTable("EntreesCahier");

        // 2. Clé primaire
        builder.HasKey(e => e.Id);

        // 3. Une seule entrée par séance (RG09.1)
        builder.HasIndex(e => e.SeanceId).IsUnique();

        // 4. Index pour accélérer les recherches par cahier et par enseignant
        builder.HasIndex(e => e.CahierTexteId);
        builder.HasIndex(e => e.EnseignantId);
        builder.HasIndex(e => e.Statut);

        // 5. Contenu obligatoire et limité (RG09.2)
        builder.Property(e => e.ContenuEnseigne)
            .IsRequired()
            .HasMaxLength(2000);

        // 6. Champs facultatifs limités (RG09.3, RG09.4)
        builder.Property(e => e.ActivitesRealisees).HasMaxLength(2000);
        builder.Property(e => e.ActivitesPrevues).HasMaxLength(2000);

        // 7. Statut stocké en entier pour rester lisible en base
        builder.Property(e => e.Statut)
            .HasConversion<int>()
            .IsRequired();

        // 8. Relation 1:1 avec la séance, sans navigation inverse sur Seance
        builder.HasOne(e => e.Seance)
            .WithOne()
            .HasForeignKey<EntreeCahier>(e => e.SeanceId)
            .OnDelete(DeleteBehavior.Restrict);

        // 9. Relation vers le cahier parent
        builder.HasOne(e => e.CahierTexte)
            .WithMany(c => c.Entrees)
            .HasForeignKey(e => e.CahierTexteId)
            .OnDelete(DeleteBehavior.Restrict);

        // 10. Relation vers l'enseignant qui a rempli
        builder.HasOne(e => e.Enseignant)
            .WithMany()
            .HasForeignKey(e => e.EnseignantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}