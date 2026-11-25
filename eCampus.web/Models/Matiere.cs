using System.ComponentModel.DataAnnotations;

namespace eCampus.web.Models
{
public class Matiere
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string Libelle { get; set; } = "";
    [StringLength(20)]
    public string Code { get; set; } = "";

    public ICollection<Programme> Programmes { get; set; } = new List<Programme>();
}
}

