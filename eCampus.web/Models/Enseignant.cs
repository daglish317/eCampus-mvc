using System.ComponentModel.DataAnnotations;
namespace eCampus.web.Models
{
public class Enseignant
{
    public int Id { get; set; }

    public string ApplicationUserId { get; set; } = "";   
    public ApplicationUser? ApplicationUser { get; set; }

    public ICollection<Affectation> Affectations { get; set; } = new List<Affectation>();
}
}