using MusicStoreAPI.Data.Data.Shop;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MusicStoreAPI.Models.CMS
{
    public class TermsAndCondition : DescriptionTable
    {
 
        [Display(Name = "Position")]
        [Required(ErrorMessage = "Enter position")]
        [Range(0, int.MaxValue, ErrorMessage = "Position must be a non-negative number.")]
        public int Position { get; set; }

    }
}
