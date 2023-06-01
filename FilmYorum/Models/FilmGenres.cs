using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmYorum.Models
{
    internal class FilmGenres
    {
        public int Id { get; set; } 
        public int FilmId { get; set; }
        public int GenreId { get; set;}
    }
    public List<Films> FilmList { get; set; }
    public FilmGenres()
    {
        FilmList = new List<Films>;
    }
}
