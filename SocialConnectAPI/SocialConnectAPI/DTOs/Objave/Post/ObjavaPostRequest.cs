using SocialConnectAPI.DTOs.Korisnici;
using SocialConnectAPI.DTOs.Tag;
using SocialConnectAPI.Models;

namespace SocialConnectAPI.DTOs.Objave.Put
{
    public class ObjavaPostRequest
    {

        public int KreatorId { get; set; }
        public List<TagPostObjavaDTO> Tagovi { get; set; }
        public bool isArhivirana { get; set; }

        public string Sadrzaj { get; set; }
    }
}
