using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCAPIs_Controller.Model;

namespace MVCAPIs_Controller.Data
{
    public class ApplicationDb : IdentityDbContext<AppUser>
    {
        public ApplicationDb(DbContextOptions options) :base(options){}

        public DbSet<Product> tblProducts { get; set; }
        public DbSet<Category> tblCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Seed(modelBuilder);
        }
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Active Wear - Men" },
                new Category { Id = 2, Name = "Active Wear - Women" },
                new Category { Id = 3, Name = "Mineral Water" },
                new Category { Id = 4, Name = "Publications" },
                new Category { Id = 5, Name = "Supplements" }
            );


            modelBuilder.Entity<Product>().HasData(
                // Active Wear - Men
                new Product { Id = 1, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "AWMGSJ", Price = 68M, IsAvailable = true },
                new Product { Id = 2, CategoryId = 1, Name = "Polo Shirt", Sku = "AWMPS", Price = 35M, IsAvailable = true },
                new Product { Id = 3, CategoryId = 1, Name = "Skater Graphic T-Shirt", Sku = "AWMSGT", Price = 33M, IsAvailable = true },
                new Product { Id = 4, CategoryId = 1, Name = "Slicker Jacket", Sku = "AWMSJ", Price = 125M, IsAvailable = true },
                new Product { Id = 5, CategoryId = 1, Name = "Thermal Fleece Jacket", Sku = "AWMTFJ", Price = 60M, IsAvailable = true },
                new Product { Id = 6, CategoryId = 1, Name = "Unisex Thermal Vest", Sku = "AWMUTV", Price = 95M, IsAvailable = true },
                new Product { Id = 7, CategoryId = 1, Name = "V-Neck Pullover", Sku = "AWMVNP", Price = 65M, IsAvailable = true },
                new Product { Id = 8, CategoryId = 1, Name = "V-Neck Sweater", Sku = "AWMVNS", Price = 65M, IsAvailable = true },
                new Product { Id = 9, CategoryId = 1, Name = "V-Neck T-Shirt", Sku = "AWMVNT", Price = 17M, IsAvailable = true },

                // Active Wear - Women
                new Product { Id = 10, CategoryId = 2, Name = "Bamboo Thermal Ski Coat", Sku = "AWWBTSC", Price = 99M, IsAvailable = true },
                new Product { Id = 11, CategoryId = 2, Name = "Cross-Back Training Tank", Sku = "AWWCTT", Price = 0M, IsAvailable = false },
                new Product { Id = 12, CategoryId = 2, Name = "Grunge Skater Jeans", Sku = "AWWGSJ", Price = 68M, IsAvailable = true },
                new Product { Id = 13, CategoryId = 2, Name = "Slicker Jacket", Sku = "AWWSJ", Price = 125M, IsAvailable = true },
                new Product { Id = 14, CategoryId = 2, Name = "Stretchy Dance Pants", Sku = "AWWSDP", Price = 55M, IsAvailable = true },
                new Product { Id = 15, CategoryId = 2, Name = "Ultra-Soft Tank Top", Sku = "AWWUSTT", Price = 22M, IsAvailable = true },
                new Product { Id = 16, CategoryId = 2, Name = "Unisex Thermal Vest", Sku = "AWWUTV", Price = 95M, IsAvailable = true },
                new Product { Id = 17, CategoryId = 2, Name = "V-Neck T-Shirt", Sku = "AWWVNT", Price = 17M, IsAvailable = true },

                // Mineral Water
                new Product { Id = 18, CategoryId = 3, Name = "Blueberry Mineral Water", Sku = "MWB", Price = 2.99M, IsAvailable = true },
                new Product { Id = 19, CategoryId = 3, Name = "Lemon-Lime Mineral Water", Sku = "MWLL", Price = 2.99M, IsAvailable = true },
                new Product { Id = 20, CategoryId = 3, Name = "Orange Mineral Water", Sku = "MWO", Price = 2.99M, IsAvailable = true },
                new Product { Id = 21, CategoryId = 3, Name = "Peach Mineral Water", Sku = "MWP", Price = 2.99M, IsAvailable = true },
                new Product { Id = 22, CategoryId = 3, Name = "Raspberry Mineral Water", Sku = "MWR", Price = 2.99M, IsAvailable = true },
                new Product { Id = 23, CategoryId = 3, Name = "Strawberry Mineral Water", Sku = "MWS", Price = 2.99M, IsAvailable = true },

                // Publications
                new Product { Id = 24, CategoryId = 4, Name = "In the Kitchen with H+ Sport", Sku = "PITK", Price = 24.99M, IsAvailable = true },

                // Supplements
                new Product { Id = 25, CategoryId = 5, Name = "Calcium 400 IU (150 tablets)", Sku = "SPC400", Price = 9.99M, IsAvailable = true },
                new Product { Id = 26, CategoryId = 5, Name = "Flaxseed Oil 1000 mg (90 softgels)", Sku = "SPFO1000", Price = 12.49M, IsAvailable = true },
                new Product { Id = 27, CategoryId = 5, Name = "Iron 65 mg (150 caplets)", Sku = "SPI65", Price = 13.99M, IsAvailable = true },
                new Product { Id = 28, CategoryId = 5, Name = "Magnesium 250 mg (100 tablets)", Sku = "SPM250", Price = 11.99M, IsAvailable = true },
                new Product { Id = 29, CategoryId = 5, Name = "Multi-Vitamin (90 capsules)", Sku = "SPMV", Price = 10.99M, IsAvailable = true },
                new Product { Id = 30, CategoryId = 5, Name = "Vitamin A 10,000 IU (125 caplets)", Sku = "SPVA", Price = 8.99M, IsAvailable = true },
                new Product { Id = 31, CategoryId = 5, Name = "Vitamin B-Complex (100 caplets)", Sku = "SPVB", Price = 9.99M, IsAvailable = true },
                new Product { Id = 32, CategoryId = 5, Name = "Vitamin C 1000 mg (100 tablets)", Sku = "SPVC", Price = 9.99M, IsAvailable = true },
                new Product { Id = 33, CategoryId = 5, Name = "Vitamin D3 1000 IU (100 tablets)", Sku = "SPVD3", Price = 12.99M, IsAvailable = true }
            );
        }

    }
}
