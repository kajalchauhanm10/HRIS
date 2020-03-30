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
using System.Data.Entity;
using HRIS.Utility;

namespace HRIS.Controllers
{
    public class PerformanceCycleController : ApiController
    {
        private HRISEntities db = new HRISEntities();

        [HttpGet]
        [Route("api/PerformanceCycle/GetReviewers")]
        public HttpResponseMessage GetReviewers()
        {
            try
            {
                List<Reviewrs> ReviewerList = new List<Reviewrs>();
                var reviewers= db.CYCReviewersMSTs.Select(x=>new { x.CYCReviewersMSTId, x.Name}).ToList();
                foreach(var per in reviewers)
                {
                    Reviewrs Reviewrsobj = new Reviewrs()
                    {
                        name=per.Name,
                        id=per.CYCReviewersMSTId
                    };
                    ReviewerList.Add(Reviewrsobj);
                }



                  return Request.CreateResponse(HttpStatusCode.OK, ReviewerList);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/PerformanceCycle/GetCycleByName/{name}")]
        public HttpResponseMessage GetCycleByName(string name)
        {
            try
            {
                string cyclename = db.CYCCycleMSTs.Where(x => x.CycleName == name).Select(x=>x.CycleName).FirstOrDefault();
                if (cyclename == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Cycle does not exist");
                }
                else

                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Cycle already exists");
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        

        [HttpPost]
        [Route("api/PerformanceCycle/PostCycle")]
        public HttpResponseMessage PostCycle(CYCCycleMST cYCCycleMST)
        {
            try
            {

                db.CYCCycleMSTs.Add(cYCCycleMST);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Created successfully");
            }


            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }



            //  return CreatedAtRoute("DefaultApi", new { id = cYCParameterMST.CYCParameterMSTId }, cYCParameterMST);
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