using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace MyVid.Data
{
    internal class EpisodioConfiguration : IEntityTypeConfiguration<Episodio>
    {
        public void Configure(EntityTypeBuilder<Episodio> modelBuilder)
        {
            modelBuilder.ToTable("Episodios");
            modelBuilder.HasKey(e => e.ID);
            modelBuilder.HasOne(e => e.Temporada).WithMany(t => t.Episodios).HasForeignKey(e => e.TemporadaID);
        }

    }
}