using SocialConnectAPI.DTOs.Korisnici;

namespace SocialConnectAPI.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public bool isAktivan { get; set; }
        
        public int pratioci { get; set; }

        //public List<Korisnik> korisniciKojePrati { get; set; }
    }
}
