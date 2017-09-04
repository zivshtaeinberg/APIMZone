using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZivBackendSystem.Models;

namespace ZivBackendSystem.Controllers
{
    public class GetMemberController : ApiController
    {

        //// POST api/AddMember
        //public HttpResponseMessage Get()
        //{
        //    return Request.CreateResponse(HttpStatusCode.OK, "");
        //}

        // POST api/GetMember/Member
        public object Post([FromBody] Member customer)
        {
            HttpResponseMessage response;

            UserDetails userDetails;
            if (!GetMemberDetails(customer, out userDetails))
            {
                response = Request.CreateResponse(HttpStatusCode.Unauthorized, userDetails);
                return response;
            }
            else
            {
                //var userDetailsJson = JsonConvert.SerializeObject(userDetails);

                response = Request.CreateResponse(HttpStatusCode.OK, userDetails);
                return response;
            }

            //return Request.CreateResponse(HttpStatusCode.OK, customer);

        }

        private bool GetMemberDetails(Member customer, out UserDetails userDetails)
        {
            if (customer != null)
            {
                using (var db = new ZivAPIMGameSystem_dbEntities())
                {
                    int iTotalCount = db.UserDetailsTable.Count();

                    userDetails = new UserDetails();

                    string first_name = customer.first_name;
                    string last_name = customer.last_name;

                    if((first_name == null) && (last_name == null))
                    {
                        return false;
                    }

                    UserDetailsTable new_user = new UserDetailsTable();

                    if (iTotalCount == 0)
                    {
                        
                        DateTime dt = DateTime.Now;

                        userDetails.UserName = "User Not Exists";
                        userDetails.UserLastName = "User Not Exists";
                        userDetails.UserEmailAddress = "User Not Exists";
                        new_user.TimeStamp = dt;

                        return false;                        
                    }
                    else
                    {
                        var rec = db.UserDetailsTable.Where(s => s.UserFirstName.Contains(first_name) && s.UserLastName.Contains(last_name));

                        if (rec == null)
                        {
                            return false;
                        }

                        var user_exist = rec.FirstOrDefault<UserDetailsTable>();
                        if (user_exist == null)
                        {
                            int iCount = rec.Count();

                            if(iCount == 0)
                            {
                                DateTime dt = DateTime.Now;

                                userDetails.UserName = "User Not Exists";
                                userDetails.UserLastName = "User Not Exists";
                                userDetails.UserEmailAddress = "User Not Exists";
                                new_user.TimeStamp = dt;

                                return false;
                            }

                            var new_rec = db.UserDetailsTable.FirstOrDefault();

                            if (new_rec == null)
                            {
                                userDetails.UserName = "User Exists";
                                userDetails.UserLastName = "User Exists";
                                userDetails.UserEmailAddress = "User Exists";

                                return true;
                            }                            
                        }
                        else
                        {
                            //user already exists in the system
                            DateTime dt = DateTime.Now;
                            userDetails.UserName = "User Exists";
                            userDetails.UserLastName = "User Exists";
                            userDetails.UserEmailAddress = "User Exists";
                            userDetails.TimeStamp = dt;

                            return false;
                        }
                    }

                }
            }

            userDetails = null;
            return false;

        }
    }
}
