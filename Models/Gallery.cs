using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GallaryPortal.Models
{
    public class Gallery
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }

        [Display(Name = "Active/Inactive")]
        public bool ActivePassive { get; set; }

        [Display(Name = "Date of Publish")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PublishData { get; set; }

        [Display(Name = "Image Of Item")]
        public string imgUrl { get; set; }

        [Display(Name = "Show in Main Banner")]
        public bool ShowInSlider { get; set; }

        public int Category { get; set; }

        [Display(Name = "Gallery Category")]
        public GalleryCategory GallaryCategory { get; set; }
    }
}