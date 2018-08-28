using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidlyApplication.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        
        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Display(Name="Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1,20)]
        [Display(Name="Number In Stock")]
        [Required]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }
    }
}