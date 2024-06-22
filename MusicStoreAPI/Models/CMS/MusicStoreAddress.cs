using MusicStoreAPI.Data.Data.Shop;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MusicStoreAPI.Models.CMS
{
    public class MusicStoreAddress : DescriptionTable
    {

        [Required(ErrorMessage = "Enter Address prt1")]

        [MaxLength(300, ErrorMessage = "Address 1 may have a maximum of 900 characters")]

        [Display(Name = "Address")]

        public string? Address { get; set; }

        [MaxLength(300, ErrorMessage = "Address 2 may have a maximum of 900 characters")]

        [Display(Name = "Address prt 2")]

        public string? Address2 { get; set; }

        [Required(ErrorMessage = "Enter Phone number")]

        [MaxLength(50, ErrorMessage = "Phone numer may have a maximum of 50 characters")]

        [Display(Name = "Phone numer")]

        public string? PhoneNumer { get; set; }

        [Required(ErrorMessage = "Enter Email address")]

        [MaxLength(90, ErrorMessage = "Email adres may have a maximum of 50 characters")]

        [Display(Name = "Email address")]

        public string? EmailAdres { get; set; }

        [Required(ErrorMessage = "Enter Position for the address")]

        [Display(Name = "Position")]

        public int? Position { get; set; }



    }
}
