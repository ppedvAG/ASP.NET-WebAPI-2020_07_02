using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Todo.Domain.Entities
{
    public class Blog
    {
        //Ef erkennt Id via Namenskonvention als PK
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Das Feld Titel benötigt eine Eingabe")]

        public string Title { get; set; }

        [MaxLength(200)]
        public string Content { get; set; }

        [DisplayName("Erstellt von")]
        public string CreatedBy { get; set; }

        [DisplayName("Erstellt am")]
        public DateTime CreatedAt { get; set; }


        //[LargerThanValidation(5)]
        //public int Rating { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
