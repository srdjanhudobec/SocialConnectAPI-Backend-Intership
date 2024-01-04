

using Microsoft.EntityFrameworkCore;
using SocialConnectAPI.DTOs.Objave.Put;
using SocialConnectAPI.Models;
using SocialConnectAPI.Repositorys.Interfaces;

namespace SocialConnectAPI.Repositorys
{
    public class ObjavaRepository:IObjaveRepository
    {
        public readonly DatabaseContext _objave;
        public ObjavaRepository(DatabaseContext context)
        {
            _objave = context;
        }

        public Objava arhivirajObjavu(int id)
        {
            Objava o1 = _objave.objave.FirstOrDefault(o => o.Id == id);
            o1.isArhivirana = true;
            _objave.SaveChanges();
            return o1;
        }


        public Objava azurirajObjavu(int id, Objava objava)
        {
            Objava o1 = _objave.objave.FirstOrDefault(o => o.Id == id);
            o1.Sadrzaj = objava.Sadrzaj;
            _objave.SaveChanges();
            return o1;
        }

        public Objava kreirajObjavu(Objava objava)
        {
            _objave.Add(objava);
            _objave.SaveChanges();
            return objava;
        }

        public Objava obrisiObjavu(int id)
        {
            Objava o1 = _objave.objave.FirstOrDefault(x => x.Id == id);
            if (o1 == null) {
                return null;
            }
            _objave.objave.Remove(o1);
            _objave.SaveChanges();
            return o1;
        }

        public Objava pretragaPoId(int id)
        {
            Objava o1 = _objave.objave.FirstOrDefault(x => x.Id == id && x.isArhivirana == false);
            if (o1 == null)
            {
                return null;
            }
            return o1;
        }

        public Objava pretragaPoKreatorId(int id)
        {
            Objava o1 = _objave.objave.FirstOrDefault(x => x.kreator.Id == id && x.isArhivirana == false); ;
            if (o1 == null)
            {
                return null;
            }
            return o1;
        }

        public Objava pretragaPoTagu(string tag)
        {
            var o1 = _objave.objave.FirstOrDefault(p => p.Tagovi.Any(t => t.Sadrzaj.Contains(tag)));
           
            if (o1 == null)
            {
                return null;
            }
            if (o1.isArhivirana == true) {
                return null;
            }
            return o1;
        }
    }
}
