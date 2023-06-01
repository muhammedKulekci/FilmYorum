using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FilmYorum.Models
{
    internal class Comments
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public string Content { get; set; }
        [Required]
        public int Rating { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public Films Films { get; set; }
        
    }
    
}
