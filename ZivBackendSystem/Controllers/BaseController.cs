using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZivBackendSystem.Models;
using Newtonsoft.Json;

namespace ZivBackendSystem.Controllers
{
    public class BaseController : ApiController
    {
        // Post api/Base
        public HttpResponseMessage Post()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "");
        }




        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}