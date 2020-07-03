using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Todo.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime CreatedBy { get; set; }

        //FK
        public int BlogId { get; set; }

        //Navigation
        public virtual Blog Blog { get; set; }

    }
}
