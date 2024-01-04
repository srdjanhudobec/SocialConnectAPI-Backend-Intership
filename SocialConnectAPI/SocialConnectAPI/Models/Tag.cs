using Microsoft.EntityFrameworkCore;

namespace SocialConnectAPI.Models
{
    public class Tag
    {
        public int id { get; set; }

        public string Sadrzaj { get; set; }

        public int objavaId { get; set; }  

    }
}
