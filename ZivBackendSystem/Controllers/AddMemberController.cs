using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using ZivBackendSystem.Models;

namespace ZivBackendSystem.Controllers
{
    public class Member
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email_address { get; set; }
        public string company_name { get; set; }
        public string user_image { get; set; }
    }

    public class AddMemberController : ApiController
    {
        //// PUT api/AddMember
        //public HttpResponseMessage Get()
        //{
        //    return Request.CreateResponse(HttpStatusCode.OK, "");
        //}

        // POST api/AddMember/strMember
        public object Post([FromBody] Member customer)
        {
            HttpResponseMessage response;

            UserDetails userDetails;
            if (!SetUserDetails(customer, out userDetails))
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

        private bool SetUserDetails(Member customer, out UserDetails userDetails)
        {
            if (customer != null)
            {
                using (var db = new ZivAPIMGameSystem_dbEntities())
                {
                    int iTotalCount = db.UserDetailsTable.Count();

                    userDetails = new UserDetails();

                    string first_name = customer.first_name;
                    string last_name = customer.last_name;

                    if (iTotalCount == 0)
                    {
                        
                        //var new_rec = db.UserDetailsTable.FirstOrDefault();

                        
                        UserDetailsTable new_user = new UserDetailsTable();
                        DateTime dt = DateTime.Now;

                        new_user.UserID = 1;
                        new_user.UserFirstName = customer.first_name;
                        new_user.UserLastName = customer.last_name;
                        new_user.UserEmailAddress = customer.email_address;
                        userDetails.TimeStamp = dt;
                        new_user.TimeStamp = dt;

                        //userDetails.UserImageLocation = rec.UserImageLocation;
                        try
                        {
                            UserDetailsTable dummy = db.UserDetailsTable.Add(new_user);
                            int i = db.SaveChanges();

                            userDetails.UserName = dummy.UserFirstName;
                            userDetails.UserLastName = dummy.UserLastName;
                            userDetails.UserEmailAddress = dummy.UserEmailAddress;                            
                        }
                        catch(System.Data.Entity.Core.EntityException EEx)
                        {
                            int x = 0;
                        }  
                        catch(Exception ex)
                        {
                            int y = 0;
                        }
                        

                        

                        return true;                        
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


                            var new_rec = db.UserDetailsTable.FirstOrDefault();

                            if (new_rec == null)
                            {
                                userDetails.UserName = "User Exists";
                                userDetails.UserLastName = "User Exists";
                                userDetails.UserEmailAddress = "User Exists";

                                return false;
                            }
                            else
                            {
                                UserDetailsTable new_user = new UserDetailsTable();
                                DateTime dt = DateTime.Now;

                                new_user.UserID = 1;
                                new_user.UserFirstName = customer.first_name;
                                new_user.UserLastName = customer.last_name;
                                new_user.UserEmailAddress = customer.email_address;
                                userDetails.TimeStamp = dt;
                                new_user.TimeStamp = dt;
                                //userDetails.UserImageLocation = rec.UserImageLocation;


                                UserDetailsTable dummy = db.UserDetailsTable.Add(new_user);
                                int i = db.SaveChanges();

                                userDetails.UserName = dummy.UserFirstName;
                                userDetails.UserLastName = dummy.UserLastName;
                                userDetails.UserEmailAddress = dummy.UserEmailAddress;
                                //userDetails.TimeStamp = dummy.TimeStamp;

                                //db.UserDetailsTable.

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
