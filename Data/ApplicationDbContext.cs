using KejaHUnt_PropertiesAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace KejaHUnt_PropertiesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PendingProperty> PendingProperties { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<GeneralFeatures> GeneralFeatures { get; set; }
        public DbSet<IndoorFeatures> IndoorFeatures { get; set; }
        public DbSet<OutDoorFeatures> OutDoorFeatures { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<PolicyDescription> PolicyDescriptions { get; set; }
        public DbSet<PendingPolicyDescription> PendingPolicyDescriptions { get; set; }
    }
}
