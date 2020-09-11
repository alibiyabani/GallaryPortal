

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GallaryPortal.Models
{
    public enum  GalleryCategory:int
    {

        [Description("Fashion")]
        [Display(Name = "Fashion")]
        Fashion=1,
        [Description("Nude")]
        [Display(Name = "Nude")]
        Nude=2,
        [Description("Concent Art")]
        [Display(Name = "Concent Art")]
        ConcentArt=3,
        [Description("Arant Grade")]
        [Display(Name = "Arant Grade")]
        ArantGrade=4,
        [Description("Celebrities")]
        [Display(Name = "Celebritiese")]
        Celebrities=5,
        [Description("Slide Show")]
        [Display(Name = "Slide Show")]
        SlideShow = 6
    }
}