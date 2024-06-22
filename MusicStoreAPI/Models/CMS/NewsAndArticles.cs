using MusicStoreAPI.Data.Data.Shop;
using System.ComponentModel.DataAnnotations;

namespace MusicStoreAPI.Models.CMS
{
    public class NewsAndArticles : DescriptionTable
    {
        [Display(Name = "Position")]
        [Required(ErrorMessage = "Enter position")]
        [Range(0, int.MaxValue, ErrorMessage = "Position must be a non-negative number.")]
        public int Position { get; set; }
        [Display(Name = "Author")]
        [Required(ErrorMessage = "Enter the author")]
        public string Author { get; set; }
        [Display(Name = "Button Name")]
        [Required(ErrorMessage = "Enter the Button Name")]
        public string BtnName { get; set; }
        [Display(Name = "News Info")]
        [Required(ErrorMessage = "Enter More Informations")]
        public string NewsInfo { get; set; }
        [Display(Name = "News Image")]
        [Required(ErrorMessage = "Enter Image Url")]
        public string NewsImage { get; set; }
        [Display(Name = "Blog Image")]
        [Required(ErrorMessage = "Enter Blog Url")]
        public string BlogImage { get; set; }

    }
}
