using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialConnectAPI.DTOs.Komentari.Get;
using SocialConnectAPI.DTOs.Komentari.Post;
using SocialConnectAPI.DTOs.Komentari.Put;
using SocialConnectAPI.Models;
using SocialConnectAPI.Repositorys.Interfaces;

namespace SocialConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]//znaci da korisni application/json tj prima samo to,da ne bi doslo do ne podudaranja sa formatom,zato recimo u post requestu ne mozemo izabrati ni jednu drugu opciju sem application/json
    [Produces("application/json", "application/xml")]//pravi i json i xml format
    public class KomentarController : ControllerBase
    {
        public readonly IKomentarRepository _komentari;
        public readonly IMapper _mapper;
        public KomentarController(IKomentarRepository komentari, IMapper mapper)
        {
            _komentari = komentari;
            _mapper = mapper;
        }
        /// <summary>
        /// Dodaj komentar
        /// </summary>
        /// <param name="komentar"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<KomentarPostResponse> CreateComment(KomentarPostRequest komentar)
        {
            var response = _mapper.Map<KomentarPostResponse>(_komentari.kreirajKomentar(_mapper.Map<Komentar>(komentar)));
            if (response == null) {
                return null;
            }
            return Ok(response);
        }
        /// <summary>
        /// Pretrazi komentar po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("by-id/")]

        public ActionResult<KomentarGetResponse> GetById(int id)
        {
            var response = _mapper.Map<KomentarGetResponse>(_komentari.pretragaPoKreatorId(id));
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        /// <summary>
        /// Azuriraj komentar po id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="komentar"></param>
        /// <returns></returns>
        [HttpPut("by-id/")]

        public ActionResult<KomentarPutResponse> UpdateComment(int id,KomentarPutRequest komentar) {
            var response = _mapper.Map<KomentarPutResponse>(_komentari.azurirajKomentar(id,_mapper.Map<Komentar>(komentar)));
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        /// <summary>
        /// Obrisi komentar po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("by-id/")]

        public ActionResult<KomentarGetResponse> DeleteComment(int id)
        {
            var response = _komentari.brisanjeKomentara(id);
            if (response == null)
            {
                return null;
            }
            return Ok(response);
        }
    }
}
