using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace VidlyApplication.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
              
        [Required]
        [Display(Name="Genre")]
        public int? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
        
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return (Id != 0) ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
        }
    }
}