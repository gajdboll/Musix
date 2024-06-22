using MusicStoreAPI.Data.Data.Shop;

namespace MusicStoreAPI.Models.Store
{
    public class Color : DescriptionTable
    {
        public ICollection<Product> ProductColors { get; set; }

    }
}
