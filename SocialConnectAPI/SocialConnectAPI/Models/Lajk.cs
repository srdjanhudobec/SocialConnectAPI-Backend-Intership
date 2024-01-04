namespace SocialConnectAPI.Models
{
    public class Lajk
    {
        public int Id { get; set; }
        public int kreatorId { get; set; }

        public int objavaId { get; set; }
        public Korisnik kreator { get; set; }


    }
}
