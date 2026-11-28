using eCampus.web.Models.EAcademie;

using System.ComponentModel.DataAnnotations;

namespace eCampus.web.Models.EAcademie
{
public class Semestre
{
    public int Id { get; set; }

    [Required, StringLength(20)]
    public string Libelle { get; set; } = "";           // "S1", "S2"

    public DateTime DateDebut { get; set; }
    public DateTime DateFin { get; set; }

    public int AnneeAcademiqueId { get; set; }
    public AnneeAcademique? AnneeAcademique { get; set; }
}
}