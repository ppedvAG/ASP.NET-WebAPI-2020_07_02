using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _001DefaultWebAPI.Controllers
{
    // WebApi Controller wird von ApiController
    public class ValueController : ApiController
    {
        //localhost:[Port]/api/Value 
        public string Get()
        {
            return "Hallo PPEDV!";
        }
    }
}
