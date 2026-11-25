using System.ComponentModel.DataAnnotations;

namespace eCampus.web.Models
{
public class Classe
{
    public int Id { get; set; }
    [Required, StringLength(50)]
    public string Libelle { get; set; } = "";           // "L1-A"

    public int NiveauId { get; set; }
    public Niveau? Niveau { get; set; }
}
}