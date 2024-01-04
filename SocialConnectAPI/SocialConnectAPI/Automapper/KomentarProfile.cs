using AutoMapper;
using SocialConnectAPI.DTOs.Komentari.Get;
using SocialConnectAPI.DTOs.Komentari.Post;
using SocialConnectAPI.DTOs.Komentari.Put;
using SocialConnectAPI.Models;

namespace SocialConnectAPI.Automapper
{
    public class KomentarProfile:Profile
    {
        public KomentarProfile() {
            CreateMap<Komentar, KomentarGetResponse>();
            CreateMap<KomentarGetResponse, Komentar>();
            CreateMap<KomentarPostRequest, Komentar>();
            CreateMap<KomentarPostResponse, Komentar>();
            CreateMap<Komentar, KomentarPostRequest>();
            CreateMap<Komentar, KomentarPostResponse>();
            CreateMap<Komentar, KomentarPutRequest>();
            CreateMap<KomentarPutRequest, Komentar>();
            CreateMap<Komentar, KomentarPutResponse>();
            CreateMap<KomentarPutResponse,Komentar>();
            
        }
    }
}
