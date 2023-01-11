namespace Livres.Models
{
    public class Livre
    {
        public int Id { get; set; }
        public int AuteurId { get; set;  }
        public string Titre { get; set; }
        public string ISBN { get; set; }
    }
}
