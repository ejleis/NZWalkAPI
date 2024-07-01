using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NzWalksDbContext : DbContext
    {
        public NzWalksDbContext(DbContextOptions<NzWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed the data for difficulties
            // Easy, Medium, Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                        Id = Guid.Parse("25ebfa42-c9e9-4d9d-a623-56cbd2573e8b"),
                        Name = "Easy"
                },
                new Difficulty()
                {
                        Id = Guid.Parse("3c1f94fb-81a4-4785-9539-1ae55bd5d73c"),
                        Name = "Medium"
                },
                new Difficulty()
                {
                        Id = Guid.Parse("e118966a-46de-4bba-b98c-754789a1be75"),
                        Name = "Hard"
                },
            };

            // seeding difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // seed data for regions
            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("a9c45d46-7223-4ba0-b0e4-4004e6ce9cbb"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/62275/pexels-photo-62275.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("be6359c1-afea-474e-9d6b-b4ace405257e"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "https://images.pexels.com/photos/62275/pexels-photo-62275.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("68df36e1-4a09-4ef2-8c00-b89af1035101"),
                    Name = "Philippines",
                    Code = "PH",
                    RegionImageUrl = "https://images.pexels.com/photos/62275/pexels-photo-62275.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("c282964b-f02b-4e06-a623-08277c2a30e0"),
                    Name = "Singapore",
                    Code = "SG",
                    RegionImageUrl = ""
                },
                new Region
                {
                    Id = Guid.Parse("4129e070-0249-482f-8c89-4fc30e51b5da"),
                    Name = "Malaysia",
                    Code = "ML",
                    RegionImageUrl = ""
                },
                new Region
                {
                    Id = Guid.Parse("9bf12e1a-0c17-451e-9add-1ce1e61c44ba"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = ""
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
