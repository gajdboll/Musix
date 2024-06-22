using MusicStoreAPI.Data.Data.Shop;
using System.ComponentModel.DataAnnotations;

namespace MusicStoreAPI.Models.CMS
{
    public class SocialMedia : DescriptionTable
    {
        [Display(Name = "Position")]
        [Required(ErrorMessage = "Enter position")]
        [Range(0, int.MaxValue, ErrorMessage = "Position must be a non-negative number.")]
        public int Position { get; set; }
        [Display(Name = "Icon")]
        [Required(ErrorMessage = "Enter icon")]
        public int SocialIcon { get; set; }
        [Display(Name = "Social Web")]
        [Required(ErrorMessage = "Enter Social Web")]
        public int SocialWeb { get; set; }

    }
}
