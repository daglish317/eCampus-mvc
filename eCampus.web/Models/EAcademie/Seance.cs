using System.ComponentModel.DataAnnotations;

namespace eCampus.web.Models.EAcademie
{
public class Seance
{
    public int Id { get; set; }

    public int ProgrammeId { get; set; }               
    public Programme? Programme { get; set; }

    public DateTime Date { get; set; }
    public TimeSpan HeureDebut { get; set; }
    public TimeSpan Duree { get; set; }
    [StringLength(50)]
    public string Salle { get; set; } = "";

    public int EnseignantId { get; set; }
    public Enseignant? Enseignant { get; set; }

    public bool EstPubliee { get; set; } = false;
    
    public int ProgrammeHebdomadaireId { get; set; }
    public ProgrammeHebdomadaire? ProgrammeHebdomadaire { get; set; }

}
}