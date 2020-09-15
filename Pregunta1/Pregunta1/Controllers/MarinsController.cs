using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Pregunta1.Models;

namespace Pregunta1.Controllers
{
    public class MarinsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Marins
        [Authorize]
        public IQueryable<Marin> GetMarins()
        {
            return db.Marins;
        }

        // GET: api/Marins/5
        [Authorize]
        [ResponseType(typeof(Marin))]
        public IHttpActionResult GetMarin(int id)
        {
            Marin marin = db.Marins.Find(id);
            if (marin == null)
            {
                return NotFound();
            }

            return Ok(marin);
        }

        // PUT: api/Marins/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMarin(int id, Marin marin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marin.marinID)
            {
                return BadRequest();
            }

            db.Entry(marin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarinExists(id))
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

        // POST: api/Marins
        [Authorize]
        [ResponseType(typeof(Marin))]
        public IHttpActionResult PostMarin(Marin marin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Marins.Add(marin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = marin.marinID }, marin);
        }

        // DELETE: api/Marins/5
        [Authorize]
        [ResponseType(typeof(Marin))]
        public IHttpActionResult DeleteMarin(int id)
        {
            Marin marin = db.Marins.Find(id);
            if (marin == null)
            {
                return NotFound();
            }

            db.Marins.Remove(marin);
            db.SaveChanges();

            return Ok(marin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarinExists(int id)
        {
            return db.Marins.Count(e => e.marinID == id) > 0;
        }
    }
}