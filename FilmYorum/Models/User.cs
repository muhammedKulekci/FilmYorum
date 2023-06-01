using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;


namespace FilmYorum.Models
{
    internal class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }

        public List<Comments> CommentsList { get; set; }
    }
    
}
