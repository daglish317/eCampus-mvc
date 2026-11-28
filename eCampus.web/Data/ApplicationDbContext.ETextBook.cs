using eCampus.web.Models.ETextBook;
using Microsoft.EntityFrameworkCore;

namespace eCampus.web.Data;

// Partie e-TextBook du DbContext : les DbSet du module cahier de texte
public partial class ApplicationDbContext
{
    public DbSet<CahierTexte> CahiersTexte => Set<CahierTexte>();
    public DbSet<EntreeCahier> EntreesCahier => Set<EntreeCahier>();
    public DbSet<DecisionCahier> DecisionsCahier => Set<DecisionCahier>();
}
