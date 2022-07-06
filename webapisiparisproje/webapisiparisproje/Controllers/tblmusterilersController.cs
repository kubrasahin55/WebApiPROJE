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
using webapisiparisproje.Models;

namespace webapisiparisproje.Controllers
{
    public class tblmusterilersController : ApiController
    {
        private siparisapiEntities db = new siparisapiEntities();

        // GET: api/tblmusterilers
        public IQueryable<tblmusteriler> Gettblmusterilers()
        {
            return db.tblmusterilers;
        }

        // GET: api/tblmusterilers/5
        [ResponseType(typeof(tblmusteriler))]
        public async Task<IHttpActionResult> Gettblmusteriler(int id)
        {
            tblmusteriler tblmusteriler = await db.tblmusterilers.FindAsync(id);
            if (tblmusteriler == null)
            {
                return NotFound();
            }

            return Ok(tblmusteriler);
        }

        // PUT: api/tblmusterilers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttblmusteriler(int id, tblmusteriler tblmusteriler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblmusteriler.musteriid)
            {
                return BadRequest();
            }

            db.Entry(tblmusteriler).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblmusterilerExists(id))
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

        // POST: api/tblmusterilers
        [ResponseType(typeof(tblmusteriler))]
        public async Task<IHttpActionResult> Posttblmusteriler(tblmusteriler tblmusteriler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblmusterilers.Add(tblmusteriler);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tblmusteriler.musteriid }, tblmusteriler);
        }

        // DELETE: api/tblmusterilers/5
        [ResponseType(typeof(tblmusteriler))]
        public async Task<IHttpActionResult> Deletetblmusteriler(int id)
        {
            tblmusteriler tblmusteriler = await db.tblmusterilers.FindAsync(id);
            if (tblmusteriler == null)
            {
                return NotFound();
            }

            db.tblmusterilers.Remove(tblmusteriler);
            await db.SaveChangesAsync();

            return Ok(tblmusteriler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblmusterilerExists(int id)
        {
            return db.tblmusterilers.Count(e => e.musteriid == id) > 0;
        }
    }
}