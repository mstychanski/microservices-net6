using DriverService.Api.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriverService.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<ApplicationUser>()
            //    .Property(p => p.Account)
            //    .HasMaxLength(20);

            builder.ApplyConfiguration(new ApplicationUserConfiguration());

            // builder.ApplyConfigurationsFromAssembly()
            // builder.Entity<ApplicationUser>()
            //    .ToTable("Users");

            base.OnModelCreating(builder);
        }
    }

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users");

            builder.Property(p => p.Account)
                .HasMaxLength(20);
        }
    }
}
