using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Korisnici.Put
{
    public class KorisnikPutResponse
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public bool isAktivan { get; set; }

        public List<Korisnik> pratioci { get; set; }
    }
}
