using System.ComponentModel.DataAnnotations;


namespace eCampus.web.Models.EAcademie
{
    public class AnneeAcademique
    {
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Libelle { get; set; } = "";          // ex: "2026-2027"

        [Required]
        public DateTime DateDebut { get; set; }

        [Required]
        public DateTime DateFin { get; set; }

        public bool EstActive { get; set; } = false;       // RG01.1

        // Navigation
        public ICollection<Semestre> Semestres { get; set; } = new List<Semestre>();
    }
}
