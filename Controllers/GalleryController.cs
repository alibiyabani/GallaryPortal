using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GallaryPortal.Models;
using IdentitySample.Models;
using System.IO;

namespace GallaryPortal.Controllers
{
    public class GalleryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Fashion()
        {
            return View();
        }
        public ActionResult Nude()
        {
            return View();
        }
        public ActionResult ConcentArt()
        {
            return View();
        }
        public ActionResult Celebritiese()
        {
            return View();
        }

        public async Task<JsonResult> GetLastGalleries()
        {
            List<Gallery> AllGallaries = new List<Gallery>();
            db.Configuration.ProxyCreationEnabled = false;
            AllGallaries = db.galleries.OrderByDescending(x => x.id).Take(5).ToList();
            return new JsonResult { Data = AllGallaries, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public async Task<ActionResult> CatId(int? id)
        {
            List<Gallery> Gallery = new List<Gallery>();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery = db.galleries.Where(x => x.Category == id).ToList();
            if (Gallery == null)
            {
                return HttpNotFound();
            }
            return new JsonResult { Data = Gallery, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public async Task<ActionResult> Banners()
        {
            List<Gallery> Gallery = new List<Gallery>();

            Gallery = db.galleries.Where(x => x.Category == 6 && x.ActivePassive == true).ToList();
            if (Gallery == null)
            {
                return HttpNotFound();
            }
            return new JsonResult { Data = Gallery, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}