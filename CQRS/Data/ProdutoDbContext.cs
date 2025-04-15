using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Data
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext ( DbContextOptions <ProdutoDbContext> options): base(options) 
        {

        }

        public DbSet <Product> produtct { get; set; }
    }
}
