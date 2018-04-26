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
using Microsoft.AspNet.Identity;
using System.Web;

namespace musicWebApplication.Controllers
{
    [Authorize]
    public class ReviewApiController : ApiController
    {
        private MusicLibrary db = new MusicLibrary();

        // GET: api/ReviewApi
        public IQueryable<Review> GetReviews()
        {
            return db.Reviews;
        }

        // GET: api/ReviewApi/5
        [ResponseType(typeof(Review))]
        public async Task<IHttpActionResult> GetReview(int id)
        {
            Review review = await db.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // PUT: api/ReviewApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReview(int id, Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != review.ReviewId)
            {
                return BadRequest();
            }

            db.Entry(review).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/ReviewApi
        [ResponseType(typeof(Review))]
        public async Task<HttpResponseMessage> PostReviews([FromBody]Review review)
        {
           review.UserId = User.Identity.GetUserId().ToString();
            
           /* if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            db.Reviews.Add(review);
            await db.SaveChangesAsync();

            var response = Request.CreateResponse(HttpStatusCode.Moved);
            String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
            String strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
            response.Headers.Location = new Uri(strUrl+"/Festival/Details/"+review.FestivalId);
            return await Task.FromResult(response); 

        //return CreatedAtRoute("DefaultRedirect", new { id = review.ReviewId }, review);
    }

        // DELETE: api/ReviewApi/5
        [ResponseType(typeof(Review))]
        public async Task<IHttpActionResult> DeleteReview(int id)
        {
            Review review = await db.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            db.Reviews.Remove(review);
            await db.SaveChangesAsync();

            return Ok(review);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReviewExists(int id)
        {
            return db.Reviews.Count(e => e.ReviewId == id) > 0;
        }
    }
}