using MusicStoreAPI.Data.Data.Shop;
using MusicStoreAPI.Models.Store;

namespace MusicStoreAPI.Models.CMS
{
    public class ProductImage : DescriptionTable
    {
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
        public Product ProductColor { get; set; }
    }
}
