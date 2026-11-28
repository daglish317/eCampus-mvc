using System.ComponentModel.DataAnnotations;
using eCampus.web.Models.EAcademie;

namespace eCampus.web.Models.ETextBook;

public class DecisionCahier
{
    public int Id { get; set; }

    // Lien vers l'entrée de cahier concernée
    public int EntreeCahierId { get; set; }
    public EntreeCahier? EntreeCahier { get; set; }

    // Responsable pédagogique qui valide/retourne (RG10.2)
    public string ApplicationUserId { get; set; } = string.Empty;
    public ApplicationUser? ApplicationUser { get; set; }

    // Type de décision
    public TypeDecisionCahier Decision { get; set; }

    // Commentaire (obligatoire si retour, RG10.3, RG10.4)
    [MaxLength(2000)]
    public string? Commentaire { get; set; }

    // Date de la décision (RG10.2)
    public DateTime DateDecision { get; set; } = DateTime.UtcNow;
}