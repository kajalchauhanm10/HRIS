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
using HRIS.Utility;

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
                List<KeyValuePair<long, string>> nameList = new List<KeyValuePair<long, string>>();
                var parameters = db.CYCParameterMSTs.Select(x => new { x.CYCParameterMSTId, x.ParameterName }).ToList();
                foreach(var param in parameters)
                {
                    KeyValuePair<long, string> nameObj = new KeyValuePair<long, string>(param.CYCParameterMSTId, param.ParameterName);
                    nameList.Add(nameObj);
                }

                return Request.CreateResponse(HttpStatusCode.OK, nameList);
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
        [Route("api/Parameter/GetStyle")]
        public HttpResponseMessage GetStyle()
        {
            try
            {
                List<CYCStyleMST> StylesList = db.CYCStyleMSTs.ToList();

                return Request.CreateResponse(HttpStatusCode.OK, StylesList);
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
                string parameterName = db.CYCParameterMSTs.Where(x => x.ParameterName == name).Select(x => x.ParameterName).FirstOrDefault();
                if(parameterName == null)
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

        [HttpGet]
        [Route("api/Parameter/GetFullParameterByName/{id}")]
        public HttpResponseMessage GetFullParameterByName(long id)
        {
            try
            {
                CYCParameterMST tempParameter = db.CYCParameterMSTs.Where(x => x.CYCParameterMSTId == id).FirstOrDefault();

                List<Question> quesList = new List<Question>();
                foreach(CYCQuesMST quesMST in tempParameter.CYCQuesMSTs)
                {
                    Question ques = new Question()
                    {
                        Id = quesMST.CYCQuesMSTId,
                        Ques = quesMST.Ques,
                        StyleValue = quesMST.CYCStyleMST.StyleVal
                    };
                    quesList.Add(ques);
                }

                Parameter parameter = new Parameter()
                {
                    Id = tempParameter.CYCParameterMSTId,
                    ParameterName = tempParameter.ParameterName,
                    QuestionsList = quesList,
                    RatingSystemName = tempParameter.CYCRatingSystemMST.RatingSystemName
                };
                return Request.CreateResponse(HttpStatusCode.OK, parameter);
            }
            catch(Exception ex)
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