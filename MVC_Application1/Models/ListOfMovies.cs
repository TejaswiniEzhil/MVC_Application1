using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVC_Application1.Models
{
    public class ListOfMovies
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="MovieName is Necessary")]
        [Display(Name ="Movie Name")]
        public string MovieName { get; set; }
        [Required(ErrorMessage = "Releasedate is Necessary")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

       
    }
}