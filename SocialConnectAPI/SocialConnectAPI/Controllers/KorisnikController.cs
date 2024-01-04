using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SocialConnectAPI.DTOs.Korisnici.Get;
using SocialConnectAPI.DTOs.Korisnici.Post;
using SocialConnectAPI.DTOs.Korisnici.Put;
using SocialConnectAPI.Models;
using SocialConnectAPI.Repositorys.Interfaces;
using System.Net.Http;

namespace SocialConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]//znaci da korisni application/json tj prima samo to,da ne bi doslo do ne podudaranja sa formatom,zato recimo u post requestu ne mozemo izabrati ni jednu drugu opciju sem application/json
    [Produces("application/json", "application/xml")]//pravi i json i xml format
    public class KorisnikController : ControllerBase
    {
        public readonly IKorisnikRepository _korisnici;
        public readonly IMapper _mapper;
        public KorisnikController(IKorisnikRepository korisnikRepository, IMapper mapper)
        {
            _korisnici = korisnikRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Dodaj Usera
        /// </summary>
        /// <param name="korisnik"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Korisnik> CreateUser(KorisnikPostRequest korisnik) {
            try
            {
                var response = _korisnici.kreirajKorisnika(_mapper.Map<Korisnik>(korisnik));
                return Ok(response);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Pretrazi usera po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("by-id/{id}")]

        public ActionResult<KorisnikGetResponse> GetById(int id) {
            var response = _mapper.Map<KorisnikGetResponse>(_korisnici.pretragaPoId(id));
            if (response == null) { return NotFound(); }
            return Ok(response);
        }

        /// <summary>
        /// Pretrazi usera po id
        /// </summary>
        /// <param name="ime"></param>
        /// <param name="prezime"></param>
        /// <returns></returns>
        [HttpGet("by-name/{ime},{prezime}")]

        public ActionResult<KorisnikGetResponse> GetByFirstAndLastName(string ime, string prezime)
        {
            var response = _mapper.Map<KorisnikGetResponse>(_korisnici.pretragaPoImenuIPrezimenu(ime, prezime));
            if (response == null) { return NotFound(); };
            return Ok(response);
        }
        /// <summary>
        /// Pretrazi usera po mailu
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        [HttpGet("by-email/{mail}")]

        public ActionResult<KorisnikGetResponse> GetByEmail(string mail)
        {
            var response = _mapper.Map<KorisnikGetResponse>(_korisnici.pretragaPoEmailu(mail));
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        /// <summary>
        /// Deaktiviraj korisnika po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("deactivate-by-id/{id}")]

        public ActionResult<KorisnikPutResponse> DeactivateById(int id) {
            var response = _mapper.Map<KorisnikPutResponse>(_korisnici.deaktivirajKorisnika(id));
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        /// <summary>
        /// Azuriraj korisnika
        /// </summary>
        /// <param name="korisnik"></param>
        /// <returns></returns>
        [HttpPut("update/")]
        public ActionResult<KorisnikPutResponse> Update(KorisnikPutRequest korisnik)
        {
            var response = _mapper.Map<KorisnikPutResponse>(_korisnici.azurirajKorisnika(_mapper.Map<Korisnik>(korisnik)));
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        /// <summary>
        /// Obrisi korisnika po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete-by-id/{id}")]

        public ActionResult<Korisnik> Delete(int id) {
            var response = _korisnici.obrisiKorisnika(id);
            if (response == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        /// <summary>
        /// Zaprati korisnika
        /// </summary>
        /// <param name="pratiocId"></param>
        /// <param name="zapracenId"></param>
        [HttpPost("zaprati")]

        public void Follow(int pratiocId,int zapracenId)
        {
            _korisnici.Zaprati(pratiocId, zapracenId);
        }
        /// <summary>
        /// Lajkuj objavu
        /// </summary>
        /// <param name="lajk"></param>
        /// <returns></returns>
        [HttpPost("lajkuj")]

        public Lajk Lajk(Lajk lajk) {
            var response = _korisnici.lajkuj(lajk);
            if (response == null) {
                return null;
            }
            return response;
        }
    }
}
