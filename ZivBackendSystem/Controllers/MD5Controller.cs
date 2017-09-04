using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZivBackendSystem.Controllers
{
    public class MD5Controller : ApiController
    {
        public HttpResponseMessage Post([FromBody]string value)
        {
            var checkSum = "c8f49c23252dce59773f86e0b08b1cd61be6c014e2d42ba9f391376458b08493";
            return Request.CreateResponse(HttpStatusCode.OK, new { MD5Value = checkSum });
        }
    }
}
