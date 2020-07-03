using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _007WebAPIActionResults.Controllers
{
    public class WithoutActionResultsController : ApiController
    {
        public object obj = null;

        // GET: api/WithoutActionResults
        public IHttpActionResult Get()
        {
            //return NotFound();
            //return BadRequest();

            return Ok(new string[] { "value1", "value2" });
        }

        // GET: api/WithoutActionResults/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/WithoutActionResults
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/WithoutActionResults/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/WithoutActionResults/5
        public void Delete(int id)
        {
        }
    }
}
