using System.ComponentModel.DataAnnotations;
namespace eCampus.web.Models.EAcademie
{

    public class Affectation
{
    public int Id { get; set; }

    public int EnseignantId { get; set; }
    public Enseignant? Enseignant { get; set; }

    public int ProgrammeId { get; set; }
    public Programme? Programme { get; set; }

    public DateTime DateDebut { get; set; }             // RG04.4
    public DateTime? DateFin { get; set; }              // null = toujours en cours
}
}

