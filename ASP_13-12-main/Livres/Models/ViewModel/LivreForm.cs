using System.ComponentModel.DataAnnotations;

namespace Livres.Models.ViewModel
{
    public class LivreForm
    {
        [Required(ErrorMessage = "Le champs 'Titre' est obligatoire")]
        public string Titre { get; set; }

        [Required(ErrorMessage = "Le champs 'Auteur' est obligatoire")]
        public Auteur Auteur { get; set; }
        [RegularExpression(@"^(?:ISBN(?:-13)?:?\ )?(?=[0-9]{13}$|(?=(?:[0-9]+[-\ ]){4})[-\ 0-9]{17}$)97[89][-\ ]?[0-9]{1,5}[-\ ]?[0-9]+[-\ ]?[0-9]+[-\ ]?[0-9]$", ErrorMessage = "Ce n'est pas un format ISBN valide")]
        public string ISBN { get; set; }
    }
}
