using SocialConnectAPI.DTOs.Tag;
using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Objave.Put
{
    public class ObjavaPutResponse
    {
        public int Id { get; set; }

        public int KreatorId { get; set; }

        public Korisnik kreator { get; set; }

        public List<TagPostObjavaDTO> Tagovi { get; set; }

        public bool isArhivirana { get; set; }

        public string Sadrzaj { get; set; }

        public List<Komentar> Komentari { get; set; }

        public List<Lajk> Lajkovi { get; set; }
    }
}
