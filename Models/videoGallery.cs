using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GallaryPortal.Models
{
    public class videoGallery
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage ="This Filed is Mandetory")]
        [Display(Name = "Video Name")]
        public string VideoName { get; set; }

        [Required(ErrorMessage = "This Filed is Mandetory")]
        [Display(Name = "YouTube Video ID")]
        public string VideoID { get; set; }
        [Display(Name ="Active/Inactive")]
        public bool Actice { get; set; }

    }
}