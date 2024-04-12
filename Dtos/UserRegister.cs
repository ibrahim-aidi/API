using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UserRegister
    {
        [Required(ErrorMessage = "Le champ 'Login' est requis.")]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'adresse e-mail est requise.")]
        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas au format valide.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le champ 'Nom' est requis.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Le nom doit contenir entre 2 et 100 caractères.")]
        public string Nom { get; set; } = string.Empty;

        public string Prenom { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le numéro de téléphone est requis.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Le format du numéro de téléphone n'est pas valide. Veuillez saisir 8 chiffres.")]
        public string Telephone { get; set; } = string.Empty;

        public string Role { get; set; } = "User";

        public bool Etat { get; set; } = true;

        [Required(ErrorMessage = "Le champ 'Mot de passe' est requis.")]
        [MinLength(6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères.")]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

