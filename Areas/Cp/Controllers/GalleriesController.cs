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

namespace GallaryPortal.Areas.Cp.Controllers
{
    public class GalleriesController : Controller
    
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]

        // GET: Gallaries
        public async Task<ActionResult> Index()
        {
            return View(await db.galleries.ToListAsync());

        }
        [Authorize]

        // GET: Gallaries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallary = await db.galleries.FindAsync(id);
            if (gallary == null)
            {
                return HttpNotFound();
            }
            return View(gallary);
        }
        [Authorize]
        // GET: Gallaries/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,ItemName,ItemDescription,ActivePassive,PublishData,imgUrl,GallaryCategory,ShowInSlider")] Gallery gallary, HttpPostedFileBase imgUrl)
        {

            if (ModelState.IsValid)
            {
                string path = UploudImage(imgUrl);


                if (path.Equals("-1"))
                {

                }
                else
                {
                    DateTime currentDateTime = DateTime.Now;
                    Gallery obj = new Gallery();
                    obj.PublishData = currentDateTime;
                    obj.ItemName = gallary.ItemName;
                    obj.imgUrl = path;
                    obj.ItemDescription = gallary.ItemDescription;
                    obj.ActivePassive = gallary.ActivePassive;
                    obj.GallaryCategory = gallary.GallaryCategory;
                    obj.ShowInSlider = gallary.ShowInSlider;
                    obj.Category = (int)gallary.GallaryCategory;
                    db.galleries.Add(obj);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");

                }

            }

            return View(gallary);
        }

        private int Int32(GalleryCategory gallaryCategory)
        {
            throw new NotImplementedException();
        }
        [Authorize]

        // GET: Gallaries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallary = await db.galleries.FindAsync(id);
            if (gallary == null)
            {
                return HttpNotFound();
            }
            return View(gallary);
        }

        // POST: Gallaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,ItemName,ItemDescription,ActivePassive,PublishData,imgUrl,GallaryCategory,ShowInSlider")] Gallery gallary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gallary).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gallary);
        }
        [Authorize]

        // GET: Gallaries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallary = await db.galleries.FindAsync(id);
            if (gallary == null)
            {
                return HttpNotFound();
            }
            return View(gallary);
        }
        [Authorize]
        // POST: Gallaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Gallery gallary = await db.galleries.FindAsync(id);
            db.galleries.Remove(gallary);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public async Task<JsonResult> GetLastGalleries()
        {
            List<Gallery> AllGallaries = new List<Gallery>();
            db.Configuration.ProxyCreationEnabled = false;
            AllGallaries = db.galleries.OrderByDescending(x => x.id).Take(10).ToList();
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

        public string UploudImage(HttpPostedFileBase file)
        {
            Random r = new Random();
            int rand = r.Next();

            string path = "-1";

            if (file != null && file.ContentLength > 0)
            {
                string extention = Path.GetExtension(file.FileName);
                if (extention.ToLower().Equals(".jpg") || extention.ToLower().Equals(".jpeg") || extention.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/img/uploud/Gallary"), rand + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "/img/uploud/Gallary/" + rand + Path.GetFileName(file.FileName);

                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }

                }
                else
                {
                    Response.Write("<script>alart('فورمت فایل مورد تایید نمی باشد!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alart('یک فایل را انتخاب فرمایید');</script>");
                path = "-1";

            }


            return path;
        }
    
}
}
