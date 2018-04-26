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

namespace musicWebApplication.API
{
    public class DjController : ApiController
    {
        private MusicLibrary db = new MusicLibrary();

        // GET: api/Dj
        public IQueryable<Dj> GetDjs()
        {
            return db.Djs;
        }

        // GET: api/Dj/5
        [ResponseType(typeof(Dj))]
        public async Task<IHttpActionResult> GetDj(int id)
        {
            Dj dj = await db.Djs.FindAsync(id);
            if (dj == null)
            {
                return NotFound();
            }

            return Ok(dj);
        }

        // PUT: api/Dj/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDj(int id, Dj dj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dj.DjId)
            {
                return BadRequest();
            }

            db.Entry(dj).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DjExists(id))
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

        // POST: api/Dj
        [ResponseType(typeof(Dj))]
        public async Task<IHttpActionResult> PostDj(Dj dj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Djs.Add(dj);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dj.DjId }, dj);
        }

        // DELETE: api/Dj/5
        [ResponseType(typeof(Dj))]
        public async Task<IHttpActionResult> DeleteDj(int id)
        {
            Dj dj = await db.Djs.FindAsync(id);
            if (dj == null)
            {
                return NotFound();
            }

            db.Djs.Remove(dj);
            await db.SaveChangesAsync();

            return Ok(dj);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DjExists(int id)
        {
            return db.Djs.Count(e => e.DjId == id) > 0;
        }
    }
}