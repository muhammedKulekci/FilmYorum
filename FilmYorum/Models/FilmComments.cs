using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmYorum.Models
{
    internal class FilmComments
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int CommentId { get; set; }
    }

    
}
