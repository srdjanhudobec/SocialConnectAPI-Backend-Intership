using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Komentari.Get
{
    public class KomentarGetResponse
    {
        public int Id { get; set; }
        public int kreatorId { get; set; }

        public Korisnik kreator { get; set; }
        public int objavaId { get; set; }

        public Objava objava { get; set; }
        public string Sadrzaj { get; set; }
    }
}
