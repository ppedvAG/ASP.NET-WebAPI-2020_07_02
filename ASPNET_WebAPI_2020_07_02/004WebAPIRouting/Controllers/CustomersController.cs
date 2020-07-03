using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _004WebAPIRouting.Controllers
{
    public class CustomersController : ApiController
    {
        // GET: api/Customers
        public IEnumerable<string> Get()
        {
            return new string[] { "Hallo J.", "Hallo S." };
        }

        // GET: api/Customers/5
        public string Get(int id)
        {
            return "Halloooooo";
        }

        // POST: api/Customers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customers/5
        public void Delete(int id)
        {
        }
    }
}
