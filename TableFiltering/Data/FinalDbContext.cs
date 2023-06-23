using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TableFiltering.Models;

namespace TableFiltering.Data
{
    public class FinalDbContext : IdentityDbContext
    {
        public FinalDbContext(DbContextOptions<FinalDbContext> options) : base(options)
        {
        }
        public DbSet<BirthCertificate> BirthCertificates { get; set; }
    }
}
