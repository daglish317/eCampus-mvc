using System.ComponentModel.DataAnnotations;
using eCampus.web.Models.EAcademie;

namespace eCampus.web.Models.ETextBook;

public class EntreeCahier
{
    public int Id { get; set; }

    // RG09.1 : une entrée par séance (contrainte unique via EF)
    public int SeanceId { get; set; }
    public Seance? Seance { get; set; }

    // Lien vers le cahier de texte du programme
    public int CahierTexteId { get; set; }
    public CahierTexte? CahierTexte { get; set; }

    // Enseignant qui remplit le cahier (RG09.7)
    public int EnseignantId { get; set; }
    public Enseignant? Enseignant { get; set; }

    // Contenu rempli par l'enseignant
    [Required]
    [MaxLength(2000)]
    public string ContenuEnseigne { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? ActivitesRealisees { get; set; }

    [MaxLength(2000)]
    public string? ActivitesPrevues { get; set; }

    // Statut de l'entrée (EF09)
    public StatutCahier Statut { get; set; } = StatutCahier.EnPreparation;

    // Date de soumission (RG09.7)
    public DateTime? DateSoumission { get; set; }

    // Historique des décisions (RG10.7)
    public ICollection<DecisionCahier> Decisions { get; set; } = new List<DecisionCahier>();
}