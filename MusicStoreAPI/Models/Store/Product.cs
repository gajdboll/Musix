using MusicStoreAPI.Data.Data.Shop;
using MusicStoreAPI.Models.CMS;
using System.ComponentModel.DataAnnotations;

namespace MusicStoreAPI.Models.Store
{
    public class Product : DescriptionTable
    {
 

        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
        public int Quantity { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }
       // public ICollection<ProductImage>? ProductImage { get; set; } = new List<ProductImage>();

    }
}
