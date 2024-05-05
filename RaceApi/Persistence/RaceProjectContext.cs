using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence.Models;

namespace RaceApi.Persistence;

public class RaceProjectContext : DbContext
{
    public RaceProjectContext(DbContextOptions<RaceProjectContext> options)
        : base(options)
    {
    }

    public DbSet<Race> Race { get; set; }
    public DbSet<Profile> Profile { get; set; }
    public DbSet<OfficialRoles> OfficialRoles { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<RaceParticipants> RaceParticipants { get; set; }
    public DbSet<RaceMarshel> RaceMarshel { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Profile>()
            .HasMany(p => p.RaceMarshel)
            .WithOne(rm => rm.Profile)
            .HasForeignKey(rm => rm.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Race>()
            .HasMany(r => r.RaceMarshel)
            .WithOne(rm => rm.Race)
            .HasForeignKey(rm => rm.RaceId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<Profile>()
            .HasMany(p => p.RaceParticipants)
            .WithOne(rm => rm.Profile)
            .HasForeignKey(rm => rm.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Race>()
            .HasMany(r => r.RaceParticipants)
            .WithOne(rm => rm.Race)
            .HasForeignKey(rm => rm.RaceId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}