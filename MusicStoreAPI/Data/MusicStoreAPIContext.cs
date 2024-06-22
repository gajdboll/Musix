using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicStoreAPI.Models.Basket;
using MusicStoreAPI.Models.CMS;
using MusicStoreAPI.Models.Store;

namespace MusicStoreAPI.Data
{
    public class MusicStoreAPIContext : IdentityDbContext<IdentityUser>
    {
        public MusicStoreAPIContext (DbContextOptions<MusicStoreAPIContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<TermsAndCondition> TermsAndCondition { get; set; }

        public DbSet<MusicStoreAddress>? MusicStoreAddress { get; set; }

        public DbSet<WebHeaders>? WebHeaders { get; set; }
        // footer info links
        public DbSet<InformationLinks>? InformationLinks { get; set; }
        // top web  links to login, reg, wishlist etc
        public DbSet<Managment>? Managment { get; set; }
        public DbSet<ProductCategory>? ProductCategory { get; set; }
        public DbSet<ProductSubCategory>? ProductSubCategory { get; set; }
        public DbSet<ProductType>? ProductType { get; set; }
        public DbSet<Manufacturer>? Manufacturer { get; set; }
        public DbSet<BasketElement>? BasketElement { get; set; }
        public DbSet<NewsAndArticles>? NewsAndArticules { get; set; }
        public DbSet<SocialMedia>? SocialMedia { get; set; }
        public DbSet<Newslatter>? Newslatter { get; set; }
        public DbSet<Report>? Report{ get; set; }
        public DbSet<Color>? Color { get; set; }
        public DbSet<Product>? Product { get; set; }
        public DbSet<PostagePrice>? Postage { get; set; }
        public DbSet<DiscountVoucher>? DiscountCode { get; set; }
        public DbSet<ProductImage>? ProductImage { get; set; }
      
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Configure the relationships for ProductColor
        //    modelBuilder.Entity<Product>()
        //        .HasKey(pc => new { pc.ProductTypeId, pc.ColorId });

        //    modelBuilder.Entity<Product>()
        //        .HasOne(pc => pc.ProductType)
        //        .WithMany(p => p.Products)
        //        .HasForeignKey(pc => pc.ProductTypeId);

        //    modelBuilder.Entity<Product>()
        //        .HasOne(pc => pc.Color)
        //        .WithMany(c => c.ProductColors)
        //        .HasForeignKey(pc => pc.ColorId);

        //    // Configure the relationships for BasketElement
        //    modelBuilder.Entity<BasketElement>()
        //        .HasOne(be => be.Product)
        //        .WithMany()
        //        .HasForeignKey(be => be.ProductId);

        //    //modelBuilder.Entity<BasketElement>()
        //    //    .HasOne(be => be.ProductColor)
        //    //    .WithMany()
        //    //    .HasForeignKey(be => new { be.ProductId, be.ColorId });

        // }
    }
}