using MusicStoreAPI.Data.Data.Shop;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicStoreAPI.Models.Store
{
    public class Manufacturer : DescriptionTable
    {

        [Display(Name = "Position")]
        [Required(ErrorMessage = "Enter position")]
        [Range(0, int.MaxValue, ErrorMessage = "Position must be a non-negative number.")]
        public int Position { get; set; }
        [Display(Name = "LogoUrl")]
        public string? LogoUrl { get; set; }
 
        [Display(Name = "Country of Origin")]
        public string? CountryOfOrigin { get; set; }

        [Display(Name = "Contact Number")]
        public string? ContactNumber { get; set; }

        [Display(Name = "Manufacturer email")]
        public string? ManufacturerEmail { get; set; }
        [Display(Name = "Manufacturer web")]
        public string? ManufacturerWeb { get; set; }
        [Display(Name = "Manufacturer Address")]
        public string? ManufactureAddress { get; set; }

        public List<ProductType> ProductTypes { get; set; }

    }
}
