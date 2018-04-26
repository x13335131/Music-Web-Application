using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using musicWebApplication.Models;

namespace musicWebApplication.Controllers
{
    [Authorize]
    public class TuneController : Controller
    {
        private MusicLibrary db = new MusicLibrary();

        // GET: Tune
        public async Task<ActionResult> Index()
        {
            var tunes = db.Tunes.Include(t => t.Djs);
            return View(await tunes.ToListAsync());
        }

        // GET: Tune/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tune tune = await db.Tunes.FindAsync(id);
            if (tune == null)
            {
                return HttpNotFound();
            }
            return View(tune);
        }

        // GET: Tune/Create
        public ActionResult Create()
        {
            ViewBag.DjId = new SelectList(db.Djs, "DjId", "Name");
            return View();
        }

        // POST: Tune/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "LouLou123@gmail.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TuneId,Name,SongName,DjId")] Tune tune)
        {
            if (ModelState.IsValid)
            {
                db.Tunes.Add(tune);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DjId = new SelectList(db.Djs, "DjId", "Name", tune.DjId);
            return View(tune);
        }

        // GET: Tune/Edit/5
        [Authorize(Users = "LouLou123@gmail.com")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tune tune = await db.Tunes.FindAsync(id);
            if (tune == null)
            {
                return HttpNotFound();
            }
            ViewBag.DjId = new SelectList(db.Djs, "DjId", "Name", tune.DjId);
            return View(tune);
        }

        // POST: Tune/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "LouLou123@gmail.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TuneId,Name,SongName,DjId")] Tune tune)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tune).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DjId = new SelectList(db.Djs, "DjId", "Name", tune.DjId);
            return View(tune);
        }

        // GET: Tune/Delete/5
        [Authorize(Users = "LouLou123@gmail.com")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tune tune = await db.Tunes.FindAsync(id);
            if (tune == null)
            {
                return HttpNotFound();
            }
            return View(tune);
        }

        // POST: Tune/Delete/5
        [Authorize(Users = "LouLou123@gmail.com")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tune tune = await db.Tunes.FindAsync(id);
            db.Tunes.Remove(tune);
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
