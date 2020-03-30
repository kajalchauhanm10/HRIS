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

        [HttpGet]
        [Route("api/Parameter/GetParameters")]
        public HttpResponseMessage GetParameters()
        {
            try
            {
                List<CYCParameterMST> ParametersList = db.CYCParameterMSTs.ToList();

                return Request.CreateResponse(HttpStatusCode.OK, ParametersList);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Parameter/GetRatingSystems")]
        public HttpResponseMessage GetRatingSystems()
        {
            try
            {
                List<CYCRatingSystemMST> RatingSystemsList = db.CYCRatingSystemMSTs.ToList();

                return Request.CreateResponse(HttpStatusCode.OK, RatingSystemsList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Parameter/GetParameterByName/{name}")]
        public HttpResponseMessage GetParameterByName(string name)
        {
            try
            {
                CYCParameterMST cYCParameterMST = db.CYCParameterMSTs.Where(x => x.ParameterName == name).FirstOrDefault();
                if(cYCParameterMST == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Parameter does not exist");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Parameter already exists");
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Parameter/PostParameterQuestionsList")]
        public HttpResponseMessage PostParameterQuestionsList(CYCParameterMST Parameter)
        {
            try
            {
                db.CYCParameterMSTs.Add(Parameter);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Questions Added successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Parameter/PostParameter")]
        public HttpResponseMessage PostParameter(CYCParameterMST cYCParameterMST)
        {
            try
            {
                db.CYCParameterMSTs.Add(cYCParameterMST);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Parameter Created successfully");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
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