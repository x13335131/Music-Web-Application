using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using musicWebApplication.Models;

namespace musicWebApplication.Controllers
{
    public class ClubApiController : ApiController
    {
        private MusicLibrary db = new MusicLibrary();

        Club[] clubs = new Club[]
        {
            new Club { Name = "Tiesto", ClubName = "3 Arena", Price = 29.99M, Established= new DateTime(1989,12,12)},
            new Club { Name = "Hannah Wants", ClubName = "Button Factory", Price = 15.99M, Established= new DateTime(1989,12,12)},
            new Club { Name = "Nervo", ClubName = "Wrights Venue", Price = 16.99M, Established= new DateTime(1989,12,12)},
            new Club { Name = "Hardwell", ClubName = "3 arena", Price = 25.99M, Established= new DateTime(1989,12,12)},
            new Club { Name = "Dense &amp; Pika", ClubName = "Twisted Pepper", Price = 14.99M, Established= new DateTime(1989,12,12)},
            new Club { Name = "Lovely Laura", ClubName = "Sin NightClub", Price = 15.99M, Established= new DateTime(1989,12,12)},
            new Club { Name = "Calvin Harris", ClubName = "3 Arena", Price = 25.99M, Established= new DateTime(1989,12,12)},
            new Club { Name = "Martin Garrix", ClubName = "Wright Venue", Price = 34.99M, Established= new DateTime(1989,12,12)}
        };
      

        // GET: api/ClubApi
        public IQueryable<Club> GetClubs()
        {
            //db.Clubs.AddRange(clubs);
            //db.SaveChangesAsync();
            return db.Clubs;
        }

        // GET: api/ClubApi/5
        [ResponseType(typeof(Club))]
        public async Task<IHttpActionResult> GetClub(string clubname)
        {
            IEnumerable<Club> club = await db.Clubs.Where(a=> a.ClubName.Contains(clubname)).ToListAsync();
            if (club == null)
            {
                return NotFound();
            }

            return Ok(club);
        }

        // PUT: api/ClubApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClub(int id, Club club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != club.ClubId)
            {
                return BadRequest();
            }

            db.Entry(club).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ClubApi
        [ResponseType(typeof(Club))]
        public async Task<IHttpActionResult> PostClub(Club club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clubs.Add(club);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = club.ClubId }, club);
        }

        // DELETE: api/ClubApi/5
        [ResponseType(typeof(Club))]
        public async Task<IHttpActionResult> DeleteClub(int id)
        {
            Club club = await db.Clubs.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }

            db.Clubs.Remove(club);
            await db.SaveChangesAsync();

            return Ok(club);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClubExists(int id)
        {
            return db.Clubs.Count(e => e.ClubId == id) > 0;
        }
    }
}