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
    public class ClubController : Controller
    {
        
        /* Club[] clubs = new Club[]
         {
             new Club { ClubId = 1, Name = "Tiesto", ClubName = "3 Arena", Price = 29.99M },
             new Club { ClubId = 2, Name = "Hannah Wants", ClubName = "Button Factory", Price = 15.99M },
             new Club { ClubId = 3, Name = "Nervo", ClubName = "Wrights Venue", Price = 16.99M },
             new Club { ClubId = 4, Name = "Hardwell", ClubName = "3 arena", Price = 25.99M },
             new Club { ClubId = 5, Name = "Dense &amp; Pika", ClubName = "Twisted Pepper", Price = 14.99M },
             new Club { ClubId = 6, Name = "Lovely Laura", ClubName = "Sin NightClub", Price = 15.99M },
             new Club { ClubId = 7, Name = "Calvin Harris", ClubName = "3 Arena", Price = 25.99M },
             new Club { ClubId = 8, Name = "Martin Garrix", ClubName = "Wright Venue", Price = 34.99M}


         };

         public IEnumerable<Club> GetAllClubs()
         {
             return clubs;
         }

         public IHttpActionResult GetProduct(int id)
         {
             var product = clubs.FirstOrDefault((p) => p.ClubId == id);
             if (product == null)
             {
                 return NotFound();
             }
             return Ok(product);
         }*/
        private MusicLibrary db = new MusicLibrary();

        // GET: Club
        
        public async System.Threading.Tasks.Task<ActionResult> Index(string clubn)
        {
           
            if(clubn == null)
            {
                return View(await db.Clubs.ToListAsync());
            }
            else {
                return View(await db.Clubs.Where(a => a.ClubName.Contains(clubn)).ToListAsync());
            }
        }

        // GET: Club/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = await db.Clubs.FindAsync(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }



        // GET: Club/Create2
        [Authorize(Users = "LouLou123@gmail.com")]
        public ActionResult Create()
        {
            ViewBag.DjId = new SelectList(db.Djs, "DjId", "Name");
            return View();
        }

        // POST: Club/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details seehttp://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ClubId,Name,ClubName,Established,DjId")] Club club)
        {
            if (ModelState.IsValid)
            {
                db.Clubs.Add(club);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DjId = new SelectList(db.Djs, "DjId", "Name", club.DjId);

            return View(club);
        }

        // GET: Club/Edit/5
        [Authorize(Users = "LouLou123@gmail.com")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = await db.Clubs.FindAsync(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: Club/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ClubId,Name,ClubName,Established")] Club club)
        {
            if (ModelState.IsValid)
            {
                db.Entry(club).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(club);
        }

        // GET: Club/Delete/5
        [Authorize(Users = "LouLou123@gmail.com")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = await db.Clubs.FindAsync(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: Club/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Club club = await db.Clubs.FindAsync(id);
            db.Clubs.Remove(club);
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
