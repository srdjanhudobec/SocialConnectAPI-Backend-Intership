
using SocialConnectAPI.Models;
using SocialConnectAPI.Repositorys.Interfaces;

namespace SocialConnectAPI.Repositorys
{
    public class KomentarRepository:IKomentarRepository
    {
        public readonly DatabaseContext _komentari;
        public KomentarRepository(DatabaseContext context)
        {
            _komentari = context;
        }

        public Komentar azurirajKomentar(int id,Komentar kom)
        {
            Komentar k1 = _komentari.komentari.FirstOrDefault(x => x.Id == id);
            if (k1 == null)
            {
                return null;
            }
            k1.Sadrzaj = kom.Sadrzaj;
            _komentari.SaveChanges();
            return k1;
        }

        public Komentar brisanjeKomentara(int id)
        {
            Komentar komentar = _komentari.komentari.FirstOrDefault(x => x.Id==id);
            //dodati uslov da ovo moze samo vlasnik komentara ili vlasnik objave
            if (komentar == null) { return null; }
            _komentari.komentari.Remove(komentar);
            _komentari.SaveChanges();
            return komentar;
        }

        public Komentar kreirajKomentar(Komentar komentar)
        {
            if (komentar == null) { return null; }
            _komentari.Add(komentar);
            _komentari.SaveChanges();
            return komentar;
        }

        public Komentar pretragaPoKreatorId(int id)
        {
            Komentar k1 = _komentari.komentari.FirstOrDefault(x=> x.Id == id);
            if (k1 == null)
            {
                return null;
            }
            return k1;
        }
    }
}
