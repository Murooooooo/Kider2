using Kider2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kider2.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }   
        public DbSet<Teacher> teachers { get; set; }
    }
}
