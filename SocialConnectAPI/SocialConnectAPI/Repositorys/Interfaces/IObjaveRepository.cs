using SocialConnectAPI.Models;

namespace SocialConnectAPI.Repositorys.Interfaces
{
    public interface IObjaveRepository
    {
        Objava pretragaPoId(int id);

        Objava pretragaPoKreatorId(int id);

        Objava pretragaPoTagu(string tag);

        Objava kreirajObjavu(Objava objava);

        Objava azurirajObjavu(int id,Objava objava);

        Objava obrisiObjavu(int id);

        Objava arhivirajObjavu(int id);
    }
}
