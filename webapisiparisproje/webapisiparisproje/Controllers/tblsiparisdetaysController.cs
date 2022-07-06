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
    public class tblsiparisdetaysController : ApiController
    {
        private siparisapiEntities db = new siparisapiEntities();

        // GET: api/tblsiparisdetays
        public IQueryable<tblsiparisdetay> Gettblsiparisdetays()
        {
            return db.tblsiparisdetays;
        }

        // GET: api/tblsiparisdetays/5
        [ResponseType(typeof(tblsiparisdetay))]
        public async Task<IHttpActionResult> Gettblsiparisdetay(int id)
        {
            tblsiparisdetay tblsiparisdetay = await db.tblsiparisdetays.FindAsync(id);
            if (tblsiparisdetay == null)
            {
                return NotFound();
            }

            return Ok(tblsiparisdetay);
        }

        // PUT: api/tblsiparisdetays/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttblsiparisdetay(int id, tblsiparisdetay tblsiparisdetay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblsiparisdetay.siparisdetayid)
            {
                return BadRequest();
            }

            db.Entry(tblsiparisdetay).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblsiparisdetayExists(id))
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

        // POST: api/tblsiparisdetays
        [ResponseType(typeof(tblsiparisdetay))]
        public async Task<IHttpActionResult> Posttblsiparisdetay(tblsiparisdetay tblsiparisdetay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblsiparisdetays.Add(tblsiparisdetay);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tblsiparisdetay.siparisdetayid }, tblsiparisdetay);
        }

        // DELETE: api/tblsiparisdetays/5
        [ResponseType(typeof(tblsiparisdetay))]
        public async Task<IHttpActionResult> Deletetblsiparisdetay(int id)
        {
            tblsiparisdetay tblsiparisdetay = await db.tblsiparisdetays.FindAsync(id);
            if (tblsiparisdetay == null)
            {
                return NotFound();
            }

            db.tblsiparisdetays.Remove(tblsiparisdetay);
            await db.SaveChangesAsync();

            return Ok(tblsiparisdetay);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblsiparisdetayExists(int id)
        {
            return db.tblsiparisdetays.Count(e => e.siparisdetayid == id) > 0;
        }
    }
}