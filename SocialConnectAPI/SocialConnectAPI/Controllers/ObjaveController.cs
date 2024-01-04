using AutoMapper;
using Azure;
using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialConnectAPI.Models;
using SocialConnectAPI.Repositorys.Interfaces;
using SocialConnectAPI.DTOs.Objave.Put;
using SocialConnectAPI.DTOs.Objave.Get;

namespace SocialConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]//znaci da korisni application/json tj prima samo to,da ne bi doslo do ne podudaranja sa formatom,zato recimo u post requestu ne mozemo izabrati ni jednu drugu opciju sem application/json
    [Produces("application/json", "application/xml")]//pravi i json i xml format
    public class ObjaveController : ControllerBase
    {
        public readonly IObjaveRepository _objave;
        public readonly IMapper _mapper;
        public ObjaveController(IObjaveRepository objave, IMapper mapper)
        {
            _objave = objave;
            _mapper = mapper;
        }
        /// <summary>
        /// Dodaj objavu
        /// </summary>
        /// <param name="objava"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<ObjavaPostResponse> CreatePost(ObjavaPostRequest objava)
        {
            var response = _mapper.Map<ObjavaPostResponse>(_objave.kreirajObjavu(_mapper.Map<Objava>(objava)));
            return response;
        }
        /// <summary>
        /// Pretrazi objavu po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("post-by-id/{id}")]

        public ActionResult<ObjavaGetResponse> GetPostById(int id) {
            var response = _mapper.Map<ObjavaGetResponse>(_objave.pretragaPoId(id));
            if (response == null) {
                return NotFound();
            }
            return Ok(response);
        }
        /// <summary>
        /// Pretrazi objavu po kreator id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("post-by-creator-id/{id}")]

        public ActionResult<ObjavaGetResponse> GetPostByCreatorId(int id)
        {
            var response = _mapper.Map<ObjavaGetResponse>(_objave.pretragaPoKreatorId(id));
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        /// <summary>
        /// Pretrazi objavu po tagu
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        [HttpGet("post-by-tag/{tag}")]

        public ActionResult<ObjavaGetResponse> GetPostByTag(string tag)
        {
            {
                var response = _mapper.Map<ObjavaGetResponse>(_objave.pretragaPoTagu(tag));
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
        }
        /// <summary>
        /// Obrisi objavu po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]

        public ActionResult<Objava> DeletePost(int id)
        {
            var response = _mapper.Map<ObjavaGetResponse>(_objave.obrisiObjavu(id));
            if (response == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        /// <summary>
        /// Arhiviraj objavu po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("archive/{id}")]

        public ActionResult<ObjavaPutResponse> ArchievePost(int id)
        {
            var response = _mapper.Map<ObjavaPutResponse>(_objave.arhivirajObjavu(id));
            if (response == null) {
                return null;
            }
            return Ok(response);
        }
        /// <summary>
        /// Azuriraj objavu
        /// </summary>
        /// <param name="objavaId"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPut("update/{objavaId}")]

        public ActionResult<ObjavaPutResponse> UpdatePost(int objavaId,ObjavaPutRequest obj)
        {
            var response = _mapper.Map<ObjavaPutResponse>(_objave.azurirajObjavu(objavaId,_mapper.Map<Objava>(obj)));
            if (response == null)
            {
                return null;
            }
            return Ok(response);
        }
    }
}
