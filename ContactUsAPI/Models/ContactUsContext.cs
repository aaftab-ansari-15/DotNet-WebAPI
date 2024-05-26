using Microsoft.EntityFrameworkCore;

namespace ContactUsAPI.Models
{
    public class ContactUsContext : DbContext
    {
        public ContactUsContext(DbContextOptions<ContactUsContext> options)
        : base(options)
        {
        }

        public DbSet<ContactUs> ContactUs { get; set; }
    }
}
