namespace Exercice4.Models
{
    public class Film
    {
        public string Titre { get; set; }
        public string Poster { get; set; }

        public Film(string titre, string poster)
        {
            Titre = titre;
            Poster = poster;
        }
    }
}
