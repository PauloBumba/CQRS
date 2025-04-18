using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext ( DbContextOptions <ProductDbContext> options): base(options) 
        {

        }

        public DbSet <Product> product { get; set; }
    }
}
