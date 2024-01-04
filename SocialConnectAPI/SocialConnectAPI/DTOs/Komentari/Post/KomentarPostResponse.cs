namespace SocialConnectAPI.DTOs.Komentari.Post
{
    public class KomentarPostResponse
    {
        public int Id { get; set; }
        public int kreatorId { get; set; }

        public int objavaId { get; set; }

        public string Sadrzaj { get; set; }
    }
}
