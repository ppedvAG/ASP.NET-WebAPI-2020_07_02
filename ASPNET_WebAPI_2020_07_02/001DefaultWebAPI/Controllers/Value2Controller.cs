using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _001DefaultWebAPI.Controllers
{
    public class Value2Controller : ApiController
    {
        // GET: api/Value2

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Value2/5
        public string Get(int id)
        {
            return "value";
        }



        // POST: api/Value2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Value2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Value2/5
        public void Delete(int id)
        {
        }
    }
}
