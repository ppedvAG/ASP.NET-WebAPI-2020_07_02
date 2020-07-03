using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _009WebAPIFormatters.Controllers
{
    public class StudentController : ApiController
    {
        // GET: api/Student
        public IEnumerable<string> Get()
        {
            IList<string> formatters = new List<string>();

            foreach (var item in GlobalConfiguration.Configuration.Formatters)
            {
                formatters.Add(item.ToString());
            }

            return formatters.AsEnumerable<string>();
        }

        // GET: api/Student/5
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
