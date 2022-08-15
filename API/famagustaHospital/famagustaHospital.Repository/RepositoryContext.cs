using famagustaHospital.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace famagustaHospital.Repository;
public class RepositoryContext : IdentityDbContext<SystemUser>
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.ApplyConfiguration(new ConfigureRoles());
        //modelBuilder.ApplyConfiguration(new ConfigureUser());
    }
    //public DbSet<Entity>? Entity { get; set; }

    public DbSet<SystemUser>? SystemUser { get; set; }

}

