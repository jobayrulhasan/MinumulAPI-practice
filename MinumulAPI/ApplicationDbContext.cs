using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MinumulAPI
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Post>posts { get; set; }
    }
}
