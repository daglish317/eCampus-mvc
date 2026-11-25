using System.ComponentModel.DataAnnotations;
using eCampus.web.Models;

namespace eCampus.web.Models
{
public class Inscription
{
    public int Id { get; set; }

    public int EtudiantId { get; set; }
    public Etudiant? Etudiant { get; set; }

    public int ClasseId { get; set; }
    public Classe? Classe { get; set; }

    public int AnneeAcademiqueId { get; set; }
    public AnneeAcademique? AnneeAcademique { get; set; }

    public DateTime DateInscription { get; set; } = DateTime.UtcNow;
}
}