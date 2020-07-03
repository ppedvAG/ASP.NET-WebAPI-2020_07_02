using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _004WebAPIRouting.Controllers
{
    public class SchoolController : ApiController
    {
        // GET: api/School

        [Route("api/student/names")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/student/names/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/School
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/School/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/School/5
        public void Delete(int id)
        {
        }
    }
}
