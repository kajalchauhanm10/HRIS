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
using HRIS.Models;

namespace HRIS.Controllers
{
    public class PerformanceCycleController : ApiController
    {
        private HRISEntities db = new HRISEntities();

        // GET: api/PerformanceCycle
        public IQueryable<CYCCycleMST> GetCYCCycleMSTs()
        {
            return db.CYCCycleMSTs;
        }

        // GET: api/PerformanceCycle/5
        [ResponseType(typeof(CYCCycleMST))]
        public IHttpActionResult GetCYCCycleMST(long id)
        {
            CYCCycleMST cYCCycleMST = db.CYCCycleMSTs.Find(id);
            if (cYCCycleMST == null)
            {
                return NotFound();
            }

            return Ok(cYCCycleMST);
        }

        // PUT: api/PerformanceCycle/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCYCCycleMST(long id, CYCCycleMST cYCCycleMST)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cYCCycleMST.CYCCycleMSTId)
            {
                return BadRequest();
            }

            db.Entry(cYCCycleMST).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CYCCycleMSTExists(id))
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

        // POST: api/PerformanceCycle
        [ResponseType(typeof(CYCCycleMST))]
        public IHttpActionResult PostCYCCycleMST(CYCCycleMST cYCCycleMST)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CYCCycleMSTs.Add(cYCCycleMST);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cYCCycleMST.CYCCycleMSTId }, cYCCycleMST);
        }

        // DELETE: api/PerformanceCycle/5
        [ResponseType(typeof(CYCCycleMST))]
        public IHttpActionResult DeleteCYCCycleMST(long id)
        {
            CYCCycleMST cYCCycleMST = db.CYCCycleMSTs.Find(id);
            if (cYCCycleMST == null)
            {
                return NotFound();
            }

            db.CYCCycleMSTs.Remove(cYCCycleMST);
            db.SaveChanges();

            return Ok(cYCCycleMST);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CYCCycleMSTExists(long id)
        {
            return db.CYCCycleMSTs.Count(e => e.CYCCycleMSTId == id) > 0;
        }
    }
}