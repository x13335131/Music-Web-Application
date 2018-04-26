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
using Microsoft.AspNet.Identity;

namespace musicWebApplication.Controllers
{
    [Authorize]
    public class FestivalController : Controller
    {
        private MusicLibrary db = new MusicLibrary();

        // GET: Festival
        public async Task<ActionResult> Index()
        {
            var festivals = db.Festivals.Include(f => f.dj);
            return View(await festivals.ToListAsync());
        }

        // GET: Festival/Details/5
       
        public async Task<ActionResult> Details([Bind(Include = "FestivalId,Name,Location,Date,DjId")]int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Festival festival = await db.Festivals.FindAsync(id);
            if (festival == null)
            {
                return HttpNotFound();
            }
            return View(festival);
        }


        // GET: Festival/Create
        [Authorize(Users = "LouLou123@gmail.com")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DjId = new SelectList(db.Djs, "DjId", "Name");
            return View();
        }

        // POST: Festival/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "LouLou123@gmail.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FestivalId,Name,Location,Date,DjId")] Festival festival)
        {            
            if (ModelState.IsValid)
            {
                db.Festivals.Add(festival);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DjId = new SelectList(db.Djs, "DjId", "Name", festival.DjId);
            return View(festival);
        }

        // GET: Festival/Edit/5
        [Authorize(Users = "LouLou123@gmail.com")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Festival festival = await db.Festivals.FindAsync(id);
            if (festival == null)
            {
                return HttpNotFound();
            }
            ViewBag.DjId = new SelectList(db.Djs, "DjId", "Name", festival.DjId);
            return View(festival);
        }

        // POST: Festival/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "LouLou123@gmail.com")]
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FestivalId,Name,Location,Date,DjId")] Festival festival)
        {
            if (ModelState.IsValid)
            {
                db.Entry(festival).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DjId = new SelectList(db.Djs, "DjId", "Name", festival.DjId);
            return View(festival);
        }

        // GET: Festival/Delete/5
        [Authorize(Users = "LouLou123@gmail.com")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Festival festival = await db.Festivals.FindAsync(id);
            if (festival == null)
            {
                return HttpNotFound();
            }
            return View(festival);
        }

        // POST: Festival/Delete/5
        [Authorize(Users = "LouLou123@gmail.com")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Festival festival = await db.Festivals.FindAsync(id);
            db.Festivals.Remove(festival);
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
