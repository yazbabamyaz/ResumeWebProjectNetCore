
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<ContactAddress> ContactAddresses { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<MyService> Services { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
