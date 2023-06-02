using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace myVid.Data
{
    internal class SerieConfiguration : IEntityTypeConfiguration<Serie>
    {
        public void Configure(EntityTypeBuilder<Serie> modelBuilder)
        {
            modelBuilder.ToTable("Series");
            modelBuilder.HasKey(s => s.ContenidoID);
        }

    }
}