using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GallaryPortal.Models;
using System.Threading.Tasks;

namespace GallaryPortal.Controllers
{
    public class VideoGalleryController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VideoGallery
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetAllVideo()
        {
            List<videoGallery> AllVideo = new List<videoGallery>();
            db.Configuration.ProxyCreationEnabled = false;
            AllVideo = db.videoGalleries.OrderByDescending(x => x.id).ToList();
            return new JsonResult { Data = AllVideo, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}