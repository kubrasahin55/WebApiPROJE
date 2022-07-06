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
    public class tblsiparislersController : ApiController
    {
        private siparisapiEntities db = new siparisapiEntities();

        // GET: api/tblsiparislers
        public IQueryable<tblsiparisler> Gettblsiparislers()
        {
            return db.tblsiparislers;
        }

        // GET: api/tblsiparislers/5
        [ResponseType(typeof(tblsiparisler))]
        public async Task<IHttpActionResult> Gettblsiparisler(int id)
        {
            tblsiparisler tblsiparisler = await db.tblsiparislers.FindAsync(id);
            if (tblsiparisler == null)
            {
                return NotFound();
            }

            return Ok(tblsiparisler);
        }

        // PUT: api/tblsiparislers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttblsiparisler(int id, tblsiparisler tblsiparisler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblsiparisler.siparisid)
            {
                return BadRequest();
            }

            db.Entry(tblsiparisler).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblsiparislerExists(id))
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

        // POST: api/tblsiparislers
        [ResponseType(typeof(tblsiparisler))]
        public async Task<IHttpActionResult> Posttblsiparisler(tblsiparisler tblsiparisler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblsiparislers.Add(tblsiparisler);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tblsiparisler.siparisid }, tblsiparisler);
        }

        // DELETE: api/tblsiparislers/5
        [ResponseType(typeof(tblsiparisler))]
        public async Task<IHttpActionResult> Deletetblsiparisler(int id)
        {
            tblsiparisler tblsiparisler = await db.tblsiparislers.FindAsync(id);
            if (tblsiparisler == null)
            {
                return NotFound();
            }

            db.tblsiparislers.Remove(tblsiparisler);
            await db.SaveChangesAsync();

            return Ok(tblsiparisler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblsiparislerExists(int id)
        {
            return db.tblsiparislers.Count(e => e.siparisid == id) > 0;
        }
    }
}