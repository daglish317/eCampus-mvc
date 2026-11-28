using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace eCampus.web.Models.EAcademie
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string? Nom { get; set; }

        [PersonalData]
        public string? Prenom { get; set; }
    }
}
