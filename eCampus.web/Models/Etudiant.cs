using System.ComponentModel.DataAnnotations;

namespace eCampus.web.Models
{
public class Etudiant
{
    public int Id { get; set; }

    [Required, StringLength(30)]
    public string Matricule { get; set; } = ""; 

    [Required, StringLength(100)]
    public string Nom { get; set; } = "";
    [Required, StringLength(100)]
    public string Prenom { get; set; } = "";

    // Navigation
    public ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
}
}