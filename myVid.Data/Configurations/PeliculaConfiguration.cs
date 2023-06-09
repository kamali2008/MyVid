using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace MyVid.Data
{
    internal class PeliculaConfiguration : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> modelBuilder)
        {
            modelBuilder.ToTable("Peliculas");
            modelBuilder.HasKey(p => p.ContenidoID);
            modelBuilder.Property(p => p.Calificacion).IsRequired();
        }

    }
}