using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard_Project_Library_2.BookModule.ViewModels
{
    public class BookPartViewModel
    {
        [Required]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int PublicationYear{ get; set; }
        [Required]
        public int ISBN { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
