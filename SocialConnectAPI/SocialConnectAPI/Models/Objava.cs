using Microsoft.EntityFrameworkCore;

namespace SocialConnectAPI.Models
{
    public class Objava
    {
        public int Id { get; set; }

        public int KreatorId { get; set; }

        public Korisnik kreator { get; set; }
        
        public List<Tag> Tagovi { get; set; }

        public bool isArhivirana { get; set; }

        public string Sadrzaj { get; set; }

        public List<Komentar> Komentari { get; set; }

        public List<Lajk> Lajkovi { get; set; }
    }
}
