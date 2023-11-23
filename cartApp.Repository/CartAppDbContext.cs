using cartApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace cartApp.Repository
{
    public class CartAppDbContext : DbContext
    {
        public CartAppDbContext(DbContextOptions<CartAppDbContext> options) : base(options) 
        {
        }
        
        public virtual DbSet<Product>? Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual async Task Commit()
        {
            var i = await base.SaveChangesAsync();
        }
    }
    
}