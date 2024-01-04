using AutoMapper;
using SocialConnectAPI.DTOs.Korisnici;
using SocialConnectAPI.DTOs.Objave.Get;
using SocialConnectAPI.DTOs.Objave.Put;
using SocialConnectAPI.DTOs.Tag;
using SocialConnectAPI.Models;

namespace SocialConnectAPI.Automapper
{
    public class ObjavaProfile:Profile
    {
        public ObjavaProfile() {
            CreateMap<ObjavaPostRequest, Objava>();
            CreateMap<Objava, ObjavaPostRequest>();
            //CreateMap<KorisnikObjavaPostRequest, Korisnik>();
            CreateMap<Objava,ObjavaPostResponse>();
            //CreateMap<Objava,ObjavaPostResponse>();
            CreateMap<ObjavaPostResponse, Objava>();
            CreateMap<TagPostObjavaDTO, Tag>();
            CreateMap<Tag, TagPostObjavaDTO>();
            CreateMap<ObjavaGetResponse, Objava>();
            CreateMap<Objava,ObjavaGetResponse>();
            CreateMap<ObjavaPutResponse, Objava>();
            CreateMap<Objava, ObjavaPutResponse>();
            CreateMap<Objava,ObjavaPutRequest>();
            CreateMap<ObjavaPutRequest,Objava>();
        }
    }
}
