using eCampus.web.Models.EAcademie;

namespace eCampus.web.Models.ETextBook;

public class CahierTexte
{
    public int Id { get; set; }

    // RG07.1 : un cahier par programme
    public int ProgrammeId { get; set; }
    public Programme? Programme { get; set; }

    // Date de création du cahier
    public DateTime DateCreation { get; set; } = DateTime.UtcNow;

    // Permet de désactiver le cahier sans le supprimer (ENF34)
    public bool Actif { get; set; } = true;

    // Navigation : les entrées associées à ce cahier
    public ICollection<EntreeCahier> Entrees { get; set; } = new List<EntreeCahier>();
}