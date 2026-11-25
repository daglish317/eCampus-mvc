using System.ComponentModel.DataAnnotations;
using eCampus.web.Models;

namespace eCampus.web.Models
{
public class ProgrammeHebdomadaire
{
    public int Id { get; set; }

    public int AnneeAcademiqueId { get; set; }
    public AnneeAcademique? AnneeAcademique { get; set; }

    public int NiveauId { get; set; }
    public Niveau? Niveau { get; set; }

    public string CheminFichier { get; set; } = "";     // le fichier importé
    public DateTime DateImport { get; set; } = DateTime.UtcNow;
    public bool EstPubliee { get; set; } = false;       // RG05.5

    public ICollection<Seance> Seances { get; set; } = new List<Seance>();
}
}