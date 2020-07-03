using _005WebAPIParameterBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _005WebAPIParameterBinding.Controllers
{
    public class StudentController : ApiController
    {

        public Student Get(int id)
        {
            Student student = new Student(123, "Horst");

            return student;
        }

        public Student Get(string name)
        {
            Student student = new Student(123, "Horst");

            return student;
        }

        public string Get(int id, string name)
        {
            Student student = new Student(123, "Horst");

            return "abc";
        }

        public Student Get( string name1, int id=1224)
        {
            Student student = new Student(123, "Horst");

            return student;
        }
    }
}
