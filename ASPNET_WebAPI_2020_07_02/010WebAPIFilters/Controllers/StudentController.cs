using _010WebAPIFilters.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _010WebAPIFilters.Controllers
{
    public class StudentController : ApiController
    {
        // GET: api/Student

        //public IHttpActionResult Get()
        //{
        //    Dictionary<object, object> obj = new Dictionary<object, object>();

        //    obj.Add("3", "UP");
        //    obj.Add("4", "AP");
        //    obj.Add("5", "J&K");
        //    obj.Add("6", "Odisha");
        //    obj.Add("7", "Delhi");
        //    obj.Add("9", "Karnataka");
        //    obj.Add("10", "Bangalore");
        //    obj.Add("21", "Rajesthan");
        //    obj.Add("31", "Jharkhand");
        //    obj.Add("41", "chennai");
        //    obj.Add("51", "jammu");
        //    obj.Add("61", "Bhubaneshwar");
        //    obj.Add("71", "Delhi");
        //    obj.Add("19", "Karnataka");

        //    return Ok(obj);
        //}


        [CacheFilter(TimeDuration = 100000)]
        public IHttpActionResult Get()
        {
            //Dictionary<object, object> obj = new Dictionary<object, object>();

            //obj.Add("3", "UP");
            //obj.Add("4", "AP");
            //obj.Add("5", "J&K");
            //obj.Add("6", "Odisha");
            //obj.Add("7", "Delhi");
            //obj.Add("9", "Karnataka");
            //obj.Add("10", "Bangalore");
            //obj.Add("21", "Rajesthan");
            //obj.Add("31", "Jharkhand");
            //obj.Add("41", "chennai");
            //obj.Add("51", "jammu");
            //obj.Add("61", "Bhubaneshwar");
            //obj.Add("71", "Delhi");
            //obj.Add("19", "Karnataka");



            return Ok(DateTime.Now);
        }



        // GET: api/Student/5
        [Logger1Attribute]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Student
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
        }
    }
}
