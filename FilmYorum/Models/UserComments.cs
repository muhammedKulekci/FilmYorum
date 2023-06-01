using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmYorum.Models
{
    internal class UserComments
    { 
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
    }
    
}
