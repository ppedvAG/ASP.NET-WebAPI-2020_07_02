using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _005WebAPIParameterBinding.Models
{
    public class Student
    {
        public Student()
        {
            this.Id = -1;
            this.Name = string.Empty;
        }

        public Student(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }


        public int Id { get; set; }
        public string Name { get; set; }
        

    }
}