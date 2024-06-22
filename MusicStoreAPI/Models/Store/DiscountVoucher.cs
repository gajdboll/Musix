using MusicStoreAPI.Data.Data.Shop;

namespace MusicStoreAPI.Models.Store
{
    public class DiscountVoucher : DescriptionTable
    {
        public string DiscountCode {get ; set; }
        public double Discount { get; set; }    
    }
}
