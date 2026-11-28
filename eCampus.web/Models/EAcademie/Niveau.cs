using System.ComponentModel.DataAnnotations;

namespace eCampus.web.Models.EAcademie
{
public class Niveau
{
    public int Id { get; set; }
    [Required, StringLength(50)]
    public string Libelle { get; set; } = "";           // "Licence 1"

    public ICollection<Classe> Classes { get; set; } = new List<Classe>();
}
}

