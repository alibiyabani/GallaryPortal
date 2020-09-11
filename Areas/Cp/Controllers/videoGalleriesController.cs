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

namespace GallaryPortal.Areas.Cp.Controllers
{
    public class videoGalleriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]

        // GET: Cp/videoGalleries
        public async Task<ActionResult> Index()
        {
            return View(await db.videoGalleries.ToListAsync());
        }

        [Authorize]

        // GET: Cp/videoGalleries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            videoGallery videoGallery = await db.videoGalleries.FindAsync(id);
            if (videoGallery == null)
            {
                return HttpNotFound();
            }
            return View(videoGallery);
        }
        [Authorize]

        // GET: Cp/videoGalleries/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]

        // POST: Cp/videoGalleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,VideoName,VideoID,Actice")] videoGallery videoGallery)
        {
            if (ModelState.IsValid)
            {
                db.videoGalleries.Add(videoGallery);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(videoGallery);
        }
        [Authorize]

        // GET: Cp/videoGalleries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            videoGallery videoGallery = await db.videoGalleries.FindAsync(id);
            if (videoGallery == null)
            {
                return HttpNotFound();
            }
            return View(videoGallery);
        }
        [Authorize]

        // POST: Cp/videoGalleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,VideoName,VideoID,Actice")] videoGallery videoGallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoGallery).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(videoGallery);
        }
        [Authorize]

        // GET: Cp/videoGalleries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            videoGallery videoGallery = await db.videoGalleries.FindAsync(id);
            if (videoGallery == null)
            {
                return HttpNotFound();
            }
            return View(videoGallery);
        }
        [Authorize]

        // POST: Cp/videoGalleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            videoGallery videoGallery = await db.videoGalleries.FindAsync(id);
            db.videoGalleries.Remove(videoGallery);
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
    }
}
