using MusicStoreAPI.Data.Data.Shop;
using MusicStoreAPI.Models.CMS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MusicStoreAPI.Models.Store
{
    public class ProductCategory : DescriptionTable
    {

        [Display(Name = "Position")]
        [Required(ErrorMessage = "Enter position")]
        [Range(0, int.MaxValue, ErrorMessage = "Position must be a non-negative number.")]
        public int Position { get; set; }

        public List<ProductSubCategory> ProductSubCategories { get; set; }

        public int? WebHeaderId { get; set; }
        [ForeignKey("WebHeaderId")]
        public WebHeaders? WebHeader { get; set; }
        [Display(Name = "Category Url")]

        public string CategoryImageUrl { get; set; }
        [Display(Name = "Category More Info")]

        public string? SubCategorMoreInfo { get; set; }
   

    }
}
