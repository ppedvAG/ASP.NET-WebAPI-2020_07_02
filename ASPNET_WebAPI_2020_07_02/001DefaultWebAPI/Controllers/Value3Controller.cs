using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _001DefaultWebAPI.Controllers
{
    public class Value3Controller : ApiController
    {
        //HTTP Verbs
        [HttpGet] 
        public string GebeEinenString()
        {
            return "Hallo Welt";
        }


        [HttpGet]
        public string GebeEinDatensatz(int id)
        {
            return "Hallo Welt" + id.ToString() ;
        }

        [HttpPost]
        public void SaveNewValue([FromBody] string value)
        {

        }


    }
}
