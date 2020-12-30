using Microsoft.EntityFrameworkCore;

namespace MyAPICore.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
