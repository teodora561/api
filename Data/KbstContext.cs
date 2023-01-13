using KbstAPI.Core.DTO;
using KbstAPI.Core.Props;
using KbstAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace KbstAPI.Data
{
    public class KbstContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; } = null!;
        public DbSet<Schema> Schemas { get; set; } = null!;

        public DbSet<Config> Configs { get; set; } = null!;

        public DbSet<AssetType> AssetTypes { get; set; } = null!;

        public DbSet<Report> Reports { get; set; } = null!;
        public KbstContext(DbContextOptions<KbstContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>().HasKey(r => r.ConnectionId);
            modelBuilder.Entity<Asset>().Property(e => e.Properties).HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Dictionary<string, object>>(v));

            //modelBuilder.Entity<AssetType>()
            //    .HasMany(a => a.SubTypes)
            //    .WithOne()
            //    .HasForeignKey(a => a.ParentId);

            modelBuilder.Entity<AssetType>().HasOne(e => e.Parent).WithMany(e => e.SubTypes).HasForeignKey(b => b.ParentId);


            modelBuilder.Entity<Schema>().HasKey(s => s.Type);
            modelBuilder.Entity<Schema>().Property(s => s.Properties).HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Dictionary<string, PropertyDB>>(v));

            modelBuilder.Entity<Config>().Property(s => s.Properties).HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Dictionary<string, PropertyConfig>>(v));

            base.OnModelCreating(modelBuilder);
        }

    }

}
