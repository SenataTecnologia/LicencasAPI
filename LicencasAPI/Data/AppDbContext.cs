using Microsoft.EntityFrameworkCore;
using LicensasApi.Models;

namespace LicensasApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Licenca> Licencas { get; set; }
    }
}
