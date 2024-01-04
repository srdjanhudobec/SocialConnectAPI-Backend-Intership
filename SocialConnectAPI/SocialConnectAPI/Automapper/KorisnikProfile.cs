using AutoMapper;
using SocialConnectAPI.DTOs.Korisnici;
using SocialConnectAPI.DTOs.Korisnici.Get;
using SocialConnectAPI.DTOs.Korisnici.Post;
using SocialConnectAPI.DTOs.Korisnici.Put;
using SocialConnectAPI.Models;

namespace SocialConnectAPI.Automapper
{
    public class KorisnikProfile:Profile
    {
        public KorisnikProfile()
        {
            CreateMap<KorisnikPostRequest, Korisnik>();
            CreateMap<Korisnik, KorisnikPostRequest>();
            CreateMap<KorisnikGetResponse, Korisnik>();
            CreateMap<Korisnik, KorisnikGetResponse>();
            CreateMap<KorisnikPutResponse, Korisnik>();
            CreateMap<Korisnik, KorisnikPutResponse>();
            CreateMap<KorisnikPutRequest, Korisnik>();
            CreateMap<Korisnik,KorisnikPutRequest>();
            CreateMap<KorisnikObjavaPostRequest, Korisnik>();
        }
    }
}
