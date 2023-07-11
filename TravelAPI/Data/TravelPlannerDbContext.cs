using Microsoft.EntityFrameworkCore;
using TravelAPI.Models.Entities;

namespace TravelAPI.Data
{
	public class TravelPlannerDbContext : DbContext
	{
		public DbSet<Destination> Destionations { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Trip> Trips { get; set; }
 		public DbSet<DestinationTrip> DestinationTrips { get; set; }
		public TravelPlannerDbContext(DbContextOptions<TravelPlannerDbContext> options) 
            : base(options)
        {
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Country>(entity =>
			{
				entity.HasKey(p => p.Id);
				entity.Property(e => e.Name).HasMaxLength(50);
				entity.Property(e => e.Code).HasMaxLength(10);
				entity.HasIndex(e => e.Code).IsUnique(); // kako dodajemo index

				entity
					.HasMany(e => e.Locations)
					.WithOne(l => l.Country)
					.HasForeignKey(l => l.CountryId);
			});

			modelBuilder.Entity<Location>(entity =>
			{
				entity.HasKey(p => p.Id);
				entity.Property(e => e.Name).HasMaxLength(100);
				entity.Property(e => e.Description).HasMaxLength(250);

			});

			modelBuilder.Entity<Destination>(entity =>
			{
				entity.HasKey(p => p.Id);
				entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
				
				entity
					.HasOne(e => e.Location)
					.WithMany(l => l.Destinations)
					.HasForeignKey(l => l.LocationId);
			});

			modelBuilder.Entity<Trip>(entity =>
			{
				entity.HasKey(p => p.Id);
				entity.Property(e => e.Title).HasMaxLength(50);
				entity.Property(e => e.Description).HasMaxLength(10);

				entity
				.HasMany(e => e.Destinations)
				.WithMany(t => t.Trips)
				.UsingEntity<DestinationTrip>(
					l => l.HasOne<Destination>().WithMany().HasForeignKey(e => e.DestionationId),
					r => r.HasOne<Trip>().WithMany().HasForeignKey(e => e.TripId)
				);
			});

			modelBuilder.Entity<User>(entity =>
			{
				entity.HasKey(p => p.Id);
				entity.Property(e => e.UserName).HasMaxLength(50);
				
				entity.HasMany(e => e.Trips).WithOne(e => e.User).HasForeignKey(e => e.UserId);
				
			});
			
			modelBuilder.Entity<DestinationTrip>(entity =>
			{
				entity.HasKey(p => new { p.DestionationId, p.TripId} );
				

			});


		}




	}
}
