using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialConnectAPI.Models
{
    public class Pratioci
    {
        public int pratiocId { get; set; }
        
        public Korisnik pratioc { get; set; }
        public int zapracenId { get; set; }

        public Korisnik zapracen { get; set; }

    }
}
