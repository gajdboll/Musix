using Microsoft.EntityFrameworkCore;
using MusicStoreAPI.Data.Data.Shop;
using MusicStoreAPI.Models.CMS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStoreAPI.Models.Store
{
    public class ProductType : DescriptionTable
    {

        [Display(Name = "Position")]
        [Required(ErrorMessage = "Enter position")]
        [Range(0, int.MaxValue, ErrorMessage = "Position must be a non-negative number.")]
        public int Position { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Enter Price")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative number.")]

        public double Price { get; set; }

        // status - is the item new => 0 /used => 1
        [Display(Name = "Product Status")]

        public bool? ProductStatus { get; set; }

        // connection with manufacturer
        public int? ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        public Manufacturer? Manufacturer { get; set; }

        public int? ProductSubCategoryId { get; set; }
        [ForeignKey("ProductSubCategoryId")]
        public ProductSubCategory? ProductSubCategory { get; set; }
        // more info -> which  can be found below Product
        public string? MoreInfo { get; set; }
        //comments - and can add comments from the system - ony visible add if u r logged in
        // faqs
        //public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<Product> Products { get; set; }
 
    }
}