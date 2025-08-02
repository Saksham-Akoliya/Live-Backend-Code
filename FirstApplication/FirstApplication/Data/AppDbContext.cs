using FirstApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<StudentDetail> StudentDetailTable { get; set; }
    }
}
