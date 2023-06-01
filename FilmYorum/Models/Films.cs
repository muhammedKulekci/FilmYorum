using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace FilmYorum.Models
{
    internal class Films
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }
        public string Genre { get; set; }

        public List<Comments> CommentsList { get; set; }

    }

}
