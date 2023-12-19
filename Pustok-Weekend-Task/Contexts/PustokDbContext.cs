using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pustok_Weekend_Task.Models;

namespace Pustok_Weekend_Task.Contexts
{
    public class PustokDbContext : IdentityDbContext
    {
        public PustokDbContext(DbContextOptions<PustokDbContext> options) : base(options) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<AppUser> AppUsers {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setting>()
                .HasData(new Setting
                {
                    Address = "Example Street 98, HH2 BacHa, New York, USA",
                    Email = "suport@hastech.com",
                    ContactNumber = "+18088 234 5678",
                    Logo = "home/assets/image/logo--footer.png",
                    Id = 1
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
