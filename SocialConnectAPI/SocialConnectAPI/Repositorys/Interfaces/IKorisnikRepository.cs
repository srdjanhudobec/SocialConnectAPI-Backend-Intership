using SocialConnectAPI.Models;

namespace SocialConnectAPI.Repositorys.Interfaces
{
    public interface IKorisnikRepository
    {
        Korisnik pretragaPoId(int pretragaPoId);

        Korisnik pretragaPoEmailu(string email);

        Korisnik pretragaPoImenuIPrezimenu(string ime, string prezime);

        Korisnik kreirajKorisnika(Korisnik korisnik);

        Korisnik azurirajKorisnika(Korisnik korisnik);

        Korisnik obrisiKorisnika(int id);

        Korisnik deaktivirajKorisnika(int id);//mozda za parametar bude prosledjen ceo objekat Korisnika
        Lajk lajkuj(Lajk lajk);
        
        void Zaprati(int pratiocId,int zapracenId);

    }
}
