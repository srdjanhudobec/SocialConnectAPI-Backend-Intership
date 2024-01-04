namespace SocialConnectAPI.DTOs.Korisnici.Post
{
    public class KorisnikPostRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }

        public bool isAktivan { get; set; }
    }
}
