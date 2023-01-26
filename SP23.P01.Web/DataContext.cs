using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {

    }

    public DbSet<TrainStation> TrainStations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TrainStation>()
            .Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(120);

        modelBuilder.Entity<TrainStation>()
            .Property(x => x.Address)
            .IsRequired();
    }
}