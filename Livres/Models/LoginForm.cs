using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Livres.Models
{
    public class LoginForm
    {
        [Required(ErrorMessage = "L'email est obligatoire")]
        [EmailAddress(ErrorMessage = "L'email n'est pas au bon format")]
        public string Email {get; set;}
        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        //[RegularExpression("[0-9]")] 
        //[RegularExpression("[a-z]")]
        // Erreur quand on ajouter 2 fois le même attribut: continuer à utiliser des méthodes static custom
        // dans le controlleur
        [MinLength(4, ErrorMessage = "Le mot de passe est trop court.")]
        [MaxLength(32, ErrorMessage = "Le mot de passe est trop long.")]
        public string Passwd { get; set; }

    }
}
