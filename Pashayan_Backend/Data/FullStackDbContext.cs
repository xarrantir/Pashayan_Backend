using Microsoft.EntityFrameworkCore;
using Pashayan_Backend.Models;

namespace Pashayan_Backend.Data
{
    public class FullStackDbContext:DbContext
    {

        public FullStackDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
