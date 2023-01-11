using System;
using System.Collections.Generic;

namespace Livres.Models
{
    public class Auteur
    {
        public int Id { get; set; }
        public string Nom { get; set; } 
        public string Prenom { get; set; }  
        public DateTime DateNaissance { get; set; }
        public List<Livre> livresEcrits { get; set; }
    }
}
