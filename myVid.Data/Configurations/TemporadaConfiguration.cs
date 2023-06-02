using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace myVid.Data
{
    internal class TemporadaConfiguration : IEntityTypeConfiguration<Temporada>
    {
        public void Configure(EntityTypeBuilder<Temporada> modelBuilder)
        {
            modelBuilder.ToTable("Temporadas");
            modelBuilder.HasKey(t => t.ID);
            modelBuilder.HasOne(t => t.Serie).WithMany(s => s.Temporadas).HasForeignKey(t => t.SerieID);
        }

    }
}