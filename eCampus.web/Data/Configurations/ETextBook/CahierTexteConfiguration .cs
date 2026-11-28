using eCampus.web.Models.ETextBook;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCampus.web.Data.Configurations.ETextBook;

public class CahierTexteConfiguration : IEntityTypeConfiguration<CahierTexte>
{
    public void Configure(EntityTypeBuilder<CahierTexte> builder)
    {
        // 1. Nom de la table
        builder.ToTable("CahiersTexte");

        // 2. Clé primaire
        builder.HasKey(c => c.Id);

        // 3. Un seul cahier par programme (RG07.2)
        builder.HasIndex(c => c.ProgrammeId).IsUnique();

        // 4. Champs obligatoires
        builder.Property(c => c.DateCreation).IsRequired();
        builder.Property(c => c.Actif).IsRequired();

        // 5. Relation vers le programme, sans suppression en cascade
        builder.HasOne(c => c.Programme)
            .WithMany()
            .HasForeignKey(c => c.ProgrammeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}