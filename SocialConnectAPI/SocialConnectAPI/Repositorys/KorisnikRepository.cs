using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SocialConnectAPI.Models;
using SocialConnectAPI.Repositorys.Interfaces;

namespace SocialConnectAPI.Repositorys
{
    public class KorisnikRepository:IKorisnikRepository
    {
        public readonly DatabaseContext _korisnici;
        public KorisnikRepository(DatabaseContext context)
        {
            _korisnici = context;
        }

        public KorisnikRepository() {
            
        }

        public Lajk lajkuj(Lajk lajk) {
            if (_korisnici.Lajkovi.Contains(lajk) == false) {
                _korisnici.Lajkovi.Add(lajk);
                Objava o1 = _korisnici.objave.FirstOrDefault(o => o.Id == lajk.objavaId);
                if (o1 != null)
                {
                    o1.Lajkovi.Add(lajk);
                }
                _korisnici.SaveChanges();
                return lajk;
            }
            return lajk;
        }

        public void Zaprati(int pratiocId, int zapracenId) {
            Pratioci p1 = new Pratioci();
            p1.pratiocId = pratiocId;
            p1.zapracenId = zapracenId;
            Korisnik zapraceni = _korisnici.korisnici.FirstOrDefault(x => x.Id == zapracenId);
            zapraceni.pratioci = zapraceni.pratioci + 1;
            _korisnici.pratioci.Add(p1);
            _korisnici.SaveChanges();
            //return p1;
        }

        public Korisnik azurirajKorisnika(Korisnik korisnik)
        {
            Korisnik k1 = _korisnici.korisnici.FirstOrDefault(x => x.Id == korisnik.Id);
            if (k1 == null)
            {
                return null;
            }
            k1.Ime = korisnik.Ime;
            k1.Prezime = korisnik.Prezime;
            k1.isAktivan = korisnik.isAktivan;
            _korisnici.SaveChanges();
            return k1;
        }

        public Korisnik deaktivirajKorisnika(int id)
        {
            Korisnik k1 = _korisnici.korisnici.FirstOrDefault(x => x.Id == id && x.isAktivan == true);
            k1.isAktivan = false;
            _korisnici.SaveChanges();
            return k1;
        }

        public Korisnik kreirajKorisnika(Korisnik korisnik)
        {
            _korisnici.Add(korisnik);
            _korisnici.SaveChanges();
            return korisnik;
        }

        public Korisnik obrisiKorisnika(int id)
        {
            Korisnik k1 = _korisnici.korisnici.FirstOrDefault(t=> t.Id == id);
            if (k1 == null) {
                return null;
            }
            _korisnici.korisnici.Remove(k1);
            _korisnici.SaveChanges();
            return k1;
        }

        public Korisnik pretragaPoEmailu(string email)
        {
            Korisnik k1 = _korisnici.korisnici.FirstOrDefault(t => t.Email.Equals(email) && t.isAktivan == true);
            if (k1 == null) { return null; }
            return k1;
        }

        public Korisnik pretragaPoId(int pretragaPoId)
        {
            Korisnik k1 = _korisnici.korisnici.FirstOrDefault(t => t.Id == pretragaPoId && t.isAktivan == true);
            if(k1==null) { return null; }
            return k1;
        }

        public Korisnik pretragaPoImenuIPrezimenu(string ime, string prezime)
        {
            Korisnik k1 = _korisnici.korisnici.FirstOrDefault(t => t.Ime.Equals(ime) && t.Prezime.Equals(prezime) && t.isAktivan == true);
            if (k1 == null){ return null; }
            return k1;
        }

        public void zapratiKorisnika(string ime, string prezime)
        {
            throw new NotImplementedException();
        }
    }
}
