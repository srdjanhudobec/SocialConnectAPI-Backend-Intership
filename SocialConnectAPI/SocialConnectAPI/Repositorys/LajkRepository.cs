

namespace SocialConnectAPI.Repositorys
{
    public class LajkRepository
    {
        public readonly DatabaseContext _lajkovi;
        public LajkRepository(DatabaseContext context)
        {
            _lajkovi = context;
        }
    }
}
