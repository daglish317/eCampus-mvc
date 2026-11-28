using eCampus.web.Models.ETextBook;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCampus.web.Data.Configurations.ETextBook;

public class DecisionCahierConfiguration : IEntityTypeConfiguration<DecisionCahier>
{
    public void Configure(EntityTypeBuilder<DecisionCahier> builder)
    {
        // 1. Nom de la table, avec une contrainte de vérification
        builder.ToTable("DecisionsCahier", t =>
            t.HasCheckConstraint(
                "CK_DecisionCahier_CommentaireRetour",
                "\"Decision\" = 0 OR (\"Commentaire\" IS NOT NULL AND TRIM(\"Commentaire\") <> '')"));

        // 2. Clé primaire
        builder.HasKey(d => d.Id);

        // 3. Index pour retrouver rapidement l'historique d'une entrée
        builder.HasIndex(d => d.EntreeCahierId);
        builder.HasIndex(d => d.ApplicationUserId);

        // 4. Décision stockée en entier
        builder.Property(d => d.Decision)
            .HasConversion<int>()
            .IsRequired();

        // 5. Commentaire limité
        builder.Property(d => d.Commentaire).HasMaxLength(2000);

        // 6. Auteur et date obligatoires (RG10.2)
        builder.Property(d => d.ApplicationUserId).IsRequired();
        builder.Property(d => d.DateDecision).IsRequired();

        // 7. Relation vers l'entrée concernée
        builder.HasOne(d => d.EntreeCahier)
            .WithMany(e => e.Decisions)
            .HasForeignKey(d => d.EntreeCahierId)
            .OnDelete(DeleteBehavior.Restrict);

        // 8. Relation vers le responsable pédagogique
        builder.HasOne(d => d.ApplicationUser)
            .WithMany()
            .HasForeignKey(d => d.ApplicationUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}