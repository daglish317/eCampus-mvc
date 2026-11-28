using eCampus.web.Common;
using eCampus.web.Models.EAcademie;
using Microsoft.AspNetCore.Identity;

namespace eCampus.web.Data.Seed;

// Insère les données indispensables au démarrage : les 4 rôles et le compte administrateur
public static class DbSeeder
{
    public static async Task InitialiserAsync(IServiceProvider services)
    {
        // 1. Récupérer les services dont on a besoin
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var configuration = services.GetRequiredService<IConfiguration>();
        var logger = services.GetRequiredService<ILoggerFactory>().CreateLogger("DbSeeder");

        // 2. Créer les 4 rôles s'ils n'existent pas déjà
        string[] roles =
        [
            Roles.AdministrateurSysteme,
            Roles.ResponsablePedagogique,
            Roles.Enseignant,
            Roles.Etudiant
        ];

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                var resultat = await roleManager.CreateAsync(new IdentityRole(role));

                if (resultat.Succeeded)
                {
                    logger.LogInformation("Rôle créé : {Role}", role);
                }
                else
                {
                    logger.LogError("Échec de création du rôle {Role}", role);
                }
            }
        }

        // 3. Lire l'email et le mot de passe de l'administrateur depuis la configuration
        var email = configuration["Seed:AdminEmail"];
        var motDePasse = configuration["Seed:AdminPassword"];

        // 4. Si les secrets ne sont pas configurés, on ne crée pas de compte
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(motDePasse))
        {
            logger.LogWarning(
                "Compte administrateur non créé. Configurez Seed:AdminEmail et Seed:AdminPassword " +
                "avec dotnet user-secrets.");
            return;
        }

        // 5. Créer le compte administrateur s'il n'existe pas déjà
        var admin = await userManager.FindByEmailAsync(email);

        if (admin == null)
        {
            admin = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                Nom = "Système",
                Prenom = "Administrateur"
            };

            var resultat = await userManager.CreateAsync(admin, motDePasse);

            if (!resultat.Succeeded)
            {
                foreach (var erreur in resultat.Errors)
                {
                    logger.LogError("Échec de création de l'administrateur : {Erreur}", erreur.Description);
                }
                return;
            }

            logger.LogInformation("Compte administrateur créé : {Email}", email);
        }

        // 6. Attribuer le rôle administrateur s'il ne l'a pas déjà
        if (!await userManager.IsInRoleAsync(admin, Roles.AdministrateurSysteme))
        {
            await userManager.AddToRoleAsync(admin, Roles.AdministrateurSysteme);
            logger.LogInformation("Rôle administrateur attribué à {Email}", email);
        }
    }
}