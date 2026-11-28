namespace eCampus.web.Models.ETextBook;

// Statut d'une entrée de cahier de texte
public enum StatutCahier
{
    // Statut d'affichage uniquement : jamais stocké en base.
    // Utilisé quand une séance n'a pas encore d'entrée de cahier.
    NonRempli = 0,

    // L'enseignant a commencé à remplir mais n'a pas encore soumis
    EnPreparation = 1,

    // Soumis, en attente de validation du responsable pédagogique
    EnAttente = 2,

    // Validé : compte pour les heures réalisées
    Valide = 3,

    // Retourné pour correction : l'enseignant peut le modifier à nouveau
    Retourne = 4
}