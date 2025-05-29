using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Cần thiết
using Microsoft.AspNetCore.Identity; // Cần thiết nếu dùng IdentityUser/IdentityRole

namespace BT6.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
         
            Products = Set<Product>();
            Categories = Set<Category>();
            ProductImages = Set<ProductImage>();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
    }
}