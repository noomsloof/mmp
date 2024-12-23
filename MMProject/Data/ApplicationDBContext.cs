using Microsoft.EntityFrameworkCore;
using MMProject.Models;

namespace MMProject.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Saving> Savings { get; set; }
    }
}
