using famagustaHospital.Entities.Models;
using famagustaHospital.Repository.Configuration;
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

        modelBuilder.ApplyConfiguration(new ConfigureRoles());
        //modelBuilder.ApplyConfiguration(new ConfigureUser());
    }
    //public DbSet<Entity>? Entity { get; set; }

    public DbSet<SystemUser>? SystemUser { get; set; }
    public DbSet<DoctorUser>? DoctorUser { get; set; }
    public DbSet<PatientUser>? PatientUser { get; set; }
    public DbSet<Medicine>? Medicine { get; set; }
    public DbSet<Chronic>? Chronic { get; set; }
    public DbSet<Session>? Session { get; set; }
    public DbSet<DoctorAvailability>? DoctorAvailablability { get; set; }
    public DbSet<Experience>? Experience { get; set; }
    public DbSet<Qualification>? Qualification { get; set; }
}

