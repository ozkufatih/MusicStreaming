using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MusicStreaming.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class MusicStreamingContextInitializer : DbContextTypesInfoInitializerBase
{
    protected override DbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<MusicStreamingEFCoreDbContext>()
            .UseSqlServer(";")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new MusicStreamingEFCoreDbContext(optionsBuilder.Options);
    }
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class MusicStreamingDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MusicStreamingEFCoreDbContext>
{
    public MusicStreamingEFCoreDbContext CreateDbContext(string[] args)
    {
        //throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
        var optionsBuilder = new DbContextOptionsBuilder<MusicStreamingEFCoreDbContext>();
        optionsBuilder.UseSqlServer("Server=BIGORANGE;Database=service;Trusted_Connection=True;TrustServerCertificate=True;");
        optionsBuilder.UseChangeTrackingProxies();
        optionsBuilder.UseObjectSpaceLinkProxies();
        return new MusicStreamingEFCoreDbContext(optionsBuilder.Options);
    }
}
[TypesInfoInitializer(typeof(MusicStreamingContextInitializer))]
public class MusicStreamingEFCoreDbContext : DbContext
{
    public MusicStreamingEFCoreDbContext(DbContextOptions<MusicStreamingEFCoreDbContext> options) : base(options)
    {
    }
    //public DbSet<ModuleInfo> ModulesInfo { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Artist> Artists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
        modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);

        modelBuilder.Entity<User>()
            .HasMany(u => u.CreatedPlaylists)
            .WithOne(p => p.CreatedBy)
            .OnDelete(DeleteBehavior.NoAction);

        //modelBuilder.Entity<Playlist>()
        //    .HasOne(p => p.CreatedBy)
        //    .WithMany(u => u.CreatedPlaylists)
        //    .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Album>()
            .HasMany(a => a.Songs)
            .WithOne(s => s.Album)
            .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<Song>()
        //    .HasOne(s => s.Album)
        //    .WithMany(a => a.Songs)
        //    .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Artist>()
            .HasMany(a => a.Albums)
            .WithOne(a => a.Artist)
            .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<Album>()
        //    .HasOne(s => s.Artist)
        //    .WithMany(a => a.Albums)
        //    .OnDelete(DeleteBehavior.NoAction);
    }
}
