using Livres.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Livres.FakeDB
{
    public class LivreDB
    {
        public static List<Livre> livres { get; set; } = new List<Livre>();
        private static int _currentId = 0;

        // CREATE 
        // Ajouter un livre dans la liste 
        public static void Add(Livre livre)
        {
            // faire l'incrémentation avant l'assignation - préincrémentation avant d'ajouter le livre dans la liste
            // préiplémentation car avant d'ajouter le livre dans la liste il faut qu'on assigne une valeur à son id !
            // une sorte d'autoincrémentation
            livre.Id = ++_currentId;
            livres.Add(livre);
        }

        // READ
        // Get by Id
        public static Livre GetById(int id)
        {
            // retourne un livre (un element de la liste) si son id correspond à l'id passé en paramètre de la méthode
            return livres.FirstOrDefault(element => element.Id == id);
        }

        // Get all
        public static List<Livre> GetAll()
        {
            return livres;
        }

        public static List<Livre> GetByAuteurId(int auteurId)
        {
            List<Livre> livresByAuteur = new List<Livre>();
            foreach (Livre livre in livres)
            {
                if (livre.AuteurId == auteurId)
                {
                    livresByAuteur.Add(livre);
                    System.Console.WriteLine("Titre: " + livre.Titre);
                }
            }
            System.Console.WriteLine("Total de livre de l'auteur: " + livresByAuteur.Count());
            return livresByAuteur; 
        }

        // Delete
        // retirer le livre (avec son id) de la liste
        public static void Delete(int id)
        {
            System.Console.WriteLine("l'id du livre dans la DB:" + id);
            System.Console.WriteLine("la taille de ma livreDB:" + livres.Count());
            Livre toDelete = LivreDB.GetById(id);
            livres.Remove(toDelete);
        }

        // Update (bonus)
        public static void Update(int id, Livre updatedLivre)
        {
            System.Console.WriteLine("la taille de ma livreDB avant:" + livres.Count());
            LivreDB.Delete(id);
            LivreDB.Add(updatedLivre);
            System.Console.WriteLine("la taille de ma livreDB après:" + livres.Count());
        }

    }
}
