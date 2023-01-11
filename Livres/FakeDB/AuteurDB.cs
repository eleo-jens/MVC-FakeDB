using Livres.Models;
using System.Collections.Generic;
using System.Linq;

namespace Livres.FakeDB
{
    // utiliser le static pouvoir utiliser la classe sans devoir l'instancier
    public static class AuteurDB
    {
        public static List<Auteur> auteurs { get; set; } = new List<Auteur>();
        private static int _currentId = 0;
        // Create 
        public static void Add(Auteur auteur)
        {
            auteur.Id = ++_currentId;
            auteurs.Add(auteur);
        }

        // Read 
        public static List<Auteur> GetAll()
        {
            return auteurs;
        }

        public static Auteur GetById(int id)
        {
            return auteurs.FirstOrDefault(item => item.Id == id);
        }

        //Delete 
        public static void Delete(int id)
        {
            List<Livre> AuthorBooks = LivreDB.GetByAuteurId(id);
            if (AuthorBooks.Count() > 0)
            {
                foreach (Livre livretoDelete in AuthorBooks)
                {
                    LivreDB.Delete(livretoDelete.Id);
                }
            }
            Auteur toDelete = AuteurDB.GetById(id);
            auteurs.Remove(toDelete);
        }

        //Update 
        public static void Update(int id, Auteur newAuteur)
        {
            List<Livre> AuthorBooks = LivreDB.GetByAuteurId(id);
            AuteurDB.Delete(id);
            AuteurDB.Add(newAuteur);
            if(AuthorBooks.Count() > 0)
            {
                foreach (Livre livreToUpdate in AuthorBooks)
                {
                    Livre newBook = new Livre
                    {
                        Titre = livreToUpdate.Titre,
                        ISBN = livreToUpdate.ISBN,
                        AuteurId = newAuteur.Id
                    };
                    LivreDB.Add(newBook);
                    System.Console.WriteLine(newBook.Titre +"-"+ newBook.ISBN +"-"+ newBook.AuteurId);
                }
            }

        }
    }
}
