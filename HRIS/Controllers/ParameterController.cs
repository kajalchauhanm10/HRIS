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
    public class ParameterController : ApiController
    {
        private HRISEntities db = new HRISEntities();

        // GET: api/Parameter
        public IQueryable<CYCParameterMST> GetCYCParameterMSTs()
        {
            return db.CYCParameterMSTs;
        }

        // GET: api/Parameter/5
        [ResponseType(typeof(CYCParameterMST))]
        public IHttpActionResult GetCYCParameterMST(long id)
        {
            CYCParameterMST cYCParameterMST = db.CYCParameterMSTs.Find(id);
            if (cYCParameterMST == null)
            {
                return NotFound();
            }

            return Ok(cYCParameterMST);
        }

        // PUT: api/Parameter/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCYCParameterMST(long id, CYCParameterMST cYCParameterMST)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cYCParameterMST.CYCParameterMSTId)
            {
                return BadRequest();
            }

            db.Entry(cYCParameterMST).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CYCParameterMSTExists(id))
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

        // POST: api/Parameter
        [ResponseType(typeof(CYCParameterMST))]
        public IHttpActionResult PostCYCParameterMST(CYCParameterMST cYCParameterMST)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CYCParameterMSTs.Add(cYCParameterMST);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cYCParameterMST.CYCParameterMSTId }, cYCParameterMST);
        }

        // DELETE: api/Parameter/5
        [ResponseType(typeof(CYCParameterMST))]
        public IHttpActionResult DeleteCYCParameterMST(long id)
        {
            CYCParameterMST cYCParameterMST = db.CYCParameterMSTs.Find(id);
            if (cYCParameterMST == null)
            {
                return NotFound();
            }

            db.CYCParameterMSTs.Remove(cYCParameterMST);
            db.SaveChanges();

            return Ok(cYCParameterMST);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CYCParameterMSTExists(long id)
        {
            return db.CYCParameterMSTs.Count(e => e.CYCParameterMSTId == id) > 0;
        }
    }
}