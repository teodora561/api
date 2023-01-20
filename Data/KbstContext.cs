using KbstAPI.Core.DTO;
using KbstAPI.Core.Props;
using KbstAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace KbstAPI.Data
{
    public class KbstContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; } = null!;
        public DbSet<Schema> Schemas { get; set; } = null!;

        public DbSet<ListConfig> Configs { get; set; } = null!;

        public DbSet<AssetType> AssetTypes { get; set; } = null!;

        public DbSet<Report> Reports { get; set; } = null!;

        public DbSet<Label> Labels { get; set; } = null!;
        public DbSet<LabelOptions> LabelOptions { get; set; } = null!;

        public DbSet<BaseContent> BaseContents { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;

        public DbSet<PropertyRef> PropertyRefs { get; set; } = null!;

        public DbSet<LayoutSection> LayoutSections { get; set; } = null!;

        public DbSet<LayoutConfig> LayoutConfigs { get; set; } = null!;
        public KbstContext(DbContextOptions<KbstContext> options) : base(options) { }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>()
                .Property(a => a.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Report>().HasKey(r => r.ConnectionId);
            var options = new JsonSerializerOptions { WriteIndented = true };

            modelBuilder.Entity<Asset>().Property(e => e.Properties).HasConversion(
                    v => System.Text.Json.JsonSerializer.Serialize(v, options),
                    v => System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(v, options));

            modelBuilder.Entity<Property>().Property(e => e.AdditionalValues).HasConversion(
                    v => System.Text.Json.JsonSerializer.Serialize(v, options),
                    v => System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(v, options));



            modelBuilder.Entity<AssetType>()
                .HasMany(a => a.SubTypes)
                .WithOne()
                .HasForeignKey(a => a.ParentId);

            modelBuilder.Entity<AssetType>()
                .HasOne(e => e.Parent)
                .WithMany(e => e.SubTypes)
                .HasForeignKey(b => b.ParentId);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Content)
                .WithOne()
                .HasForeignKey(c => c.ParentId);

            modelBuilder.Entity<LayoutSection>().Property(s => s.ColumnRatio).HasConversion(

                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<ICollection<int>>(v));

            modelBuilder.Entity<BaseContent>().Property(s => s.SplitRatio).HasConversion(

                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<ICollection<int>>(v));

            modelBuilder.Entity<Schema>().HasKey(s => s.ID);
            modelBuilder.Entity<Schema>().Property(s => s.Properties).HasConversion(
                    v => System.Text.Json.JsonSerializer.Serialize(v, options),
                    v => System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Property>>(v, options));

            modelBuilder.Entity<ListConfig>().Property(s => s.Properties).HasConversion(
                    v => System.Text.Json.JsonSerializer.Serialize(v, options),
                    v => System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, PropertyConfig>>(v, options));

            base.OnModelCreating(modelBuilder);
        }

    }

}
