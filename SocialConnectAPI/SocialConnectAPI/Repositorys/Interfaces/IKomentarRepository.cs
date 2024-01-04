using SocialConnectAPI.Models;

namespace SocialConnectAPI.Repositorys.Interfaces
{
    public interface IKomentarRepository
    {
        Komentar pretragaPoKreatorId(int id);

        Komentar kreirajKomentar(Komentar komentar);

        Komentar azurirajKomentar(int id,Komentar komentar);

        Komentar brisanjeKomentara(int id);
    }
}
