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
    public class DjController : Controller
    {
        private MusicLibrary db = new MusicLibrary();

        // GET: Dj
        public async Task<ActionResult> Index()
        {
            return View(await db.Djs.ToListAsync());
        }

        // GET: Dj/Details/5
        [Authorize(Users = "LouLou123@gmail.com")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dj dj = await db.Djs.FindAsync(id);
            if (dj == null)
            {
                return HttpNotFound();
            }
            return View(dj);
        }

        // GET: Dj/Create
        [Authorize(Users = "LouLou123@gmail.com")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dj/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "LouLou123@gmail.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DjId,Name,Genre")] Dj dj)
        {
            if (ModelState.IsValid)
            {
                db.Djs.Add(dj);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dj);
        }

        // GET: Dj/Edit/5
        [Authorize(Users = "LouLou123@gmail.com")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dj dj = await db.Djs.FindAsync(id);
            if (dj == null)
            {
                return HttpNotFound();
            }
            return View(dj);
        }

        // POST: Dj/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "LouLou123@gmail.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DjId,Name,Genre")] Dj dj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dj).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dj);
        }

        // GET: Dj/Delete/5
        [Authorize(Users = "LouLou123@gmail.com")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dj dj = await db.Djs.FindAsync(id);
            if (dj == null)
            {
                return HttpNotFound();
            }
            return View(dj);
        }

        // POST: Dj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Dj dj = await db.Djs.FindAsync(id);
            db.Djs.Remove(dj);
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
        public ActionResult Search()
        {
            return View();
        }
    }
}
