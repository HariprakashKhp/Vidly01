using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly01.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1,20)]
        public int NumberInStock { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public Genre genre { get; set; }

        [Display(Name="Genre")]
        [Required]
        public int genreId { get; set; }

        public int NumberAvailable { get; set; }

    }
}