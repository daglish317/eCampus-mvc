using System.ComponentModel.DataAnnotations;
using eCampus.web.Models.EAcademie;

namespace eCampus.web.Models.EAcademie
{
public class Programme
{
    public int Id { get; set; }

    public int MatiereId { get; set; }
    public Matiere? Matiere { get; set; }

    public int NiveauId { get; set; }
    public Niveau? Niveau { get; set; }

    public int SemestreId { get; set; }
    public Semestre? Semestre { get; set; }

    public int AnneeAcademiqueId { get; set; }
    public AnneeAcademique? AnneeAcademique { get; set; }

    public DateTime DateEffet { get; set; } = DateTime.UtcNow;  // RG03.5
    public bool EstActif { get; set; } = true;
}
}