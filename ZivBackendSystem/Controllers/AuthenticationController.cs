using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
//using SafeChargeBackaendAPI.Models;
using Newtonsoft.Json;
using ZivBackendSystem.Models;

namespace ZivBackendSystem.Controllers
{
    public class AuthenticationController : ApiController
    {
        //// GET api/Authentication
        //public HttpResponseMessage Get()
        //{
        //    return Request.CreateResponse(HttpStatusCode.OK, "");
        //}

        // GET api/Authentication/id
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response;

            UserDetails userDetails;
            if (!GetUserDetails(id, out userDetails))
            {
                response = Request.CreateResponse(HttpStatusCode.Unauthorized, id);
                return response;
            }
            else
            {
                //var userDetailsJson = JsonConvert.SerializeObject(userDetails);

                response = Request.CreateResponse(HttpStatusCode.OK, userDetails);
                return response;
            }
        }

        private bool GetUserDetails(int userId, out UserDetails userDetails)
        {
            /*userDetails = new UserDetails();

            userDetails.UserId = 1;
            userDetails.MerchantId = "2";
            userDetails.MerchantSiteId = "3";

            return true;*/
            using (var db = new ZivAPIMGameSystem_dbEntities())
            {
                userDetails = new UserDetails();

                var rec = db.UserDetailsTable.FirstOrDefault(x => x.UserID == userId);

                if (rec == null)
                {
                    return false;
                }

                userDetails.UserId = userId;
                userDetails.UserName = rec.UserFirstName;
                userDetails.UserLastName = rec.UserLastName;
                userDetails.UserEmailAddress = rec.UserEmailAddress;
                userDetails.UserImageLocation = rec.UserImageLocation;

                return true;
            }
        }

    }
}