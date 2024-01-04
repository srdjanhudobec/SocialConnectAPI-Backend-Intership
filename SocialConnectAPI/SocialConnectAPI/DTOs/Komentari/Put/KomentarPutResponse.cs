using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Komentari.Put
{
    public class KomentarPutResponse
    {
        public int Id { get; set; }
        public int kreatorId { get; set; }
        public int objavaId { get; set; }
        public string Sadrzaj { get; set; }
    }
}
