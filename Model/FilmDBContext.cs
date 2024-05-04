using Microsoft.EntityFrameworkCore;

namespace mdb_project.Model
{
    public class FilmDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public FilmDBContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}