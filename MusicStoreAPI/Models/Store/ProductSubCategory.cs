using MusicStoreAPI.Data.Data.Shop;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStoreAPI.Models.Store
{
    public class ProductSubCategory : DescriptionTable
    {
        [Display(Name = "Position")]
        [Required(ErrorMessage = "Enter position")]
        [Range(0, int.MaxValue, ErrorMessage = "Position must be a non-negative number.")]
        public int Position { get; set; }
        [Display(Name = "ProductCategoryId")]
        public int? ProductCategoryId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public ProductCategory? ProductCategory { get; set; }
        public List<ProductType>? Products { get; set; }
        [Display(Name = "SubCategory Image Url")]

        public string? SubCategoryImageUrl { get; set; }
        [Display(Name = "SubCategory More Info")]

        public string? SubCategorMoreInfo { get; set; }
 
 
    }
}
