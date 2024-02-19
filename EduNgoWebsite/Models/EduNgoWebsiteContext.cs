using Microsoft.EntityFrameworkCore;

namespace EduNgoWebsite.Models

{
    public class EduNgoWebsiteContext : DbContext
    {
        public EduNgoWebsiteContext(DbContextOptions<EduNgoWebsiteContext> options) : base(options)
        {

        }

        public DbSet<Volunteer> tbl_Volunteer { get; set; }
        public DbSet<State> tbl_State { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Enable lazy loading
            optionsBuilder.UseLazyLoadingProxies(); // This line enables lazy loading
        }
    }
}
