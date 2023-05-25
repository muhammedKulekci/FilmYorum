using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Models
{
    internal class Role
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }
        public List<User> User { get; set;}
    }
}
