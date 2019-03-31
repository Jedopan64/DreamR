using Microsoft.EntityFrameworkCore;
using DreamRF.Features;

namespace DreamRF.Data{
 public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}