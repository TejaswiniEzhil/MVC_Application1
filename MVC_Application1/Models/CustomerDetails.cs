using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Application1.Models
{
    public class CustomerDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name="Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Dob is required")]
        [Display(Name = "Your dOB")]
        public DateTime? Birthdate { get; set; }

        
        public string Gender { get; set; }
        
        public  MembershipType1 Member { get; set; }
        
        public int? MembershipType1Id { get; set; }

        
    }
}