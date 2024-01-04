namespace SocialConnectAPI.DTOs.Korisnici.Put
{
    public class KorisnikPutRequest
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public bool isAktivan { get; set; }
    }
}
