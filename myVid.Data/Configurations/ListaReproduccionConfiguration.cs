using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace MyVid.Data
{
    internal class ListaReproduccionConfiguration : IEntityTypeConfiguration<ListaReproduccion>
    {
        public void Configure(EntityTypeBuilder<ListaReproduccion> modelBuilder)
        {
            modelBuilder.ToTable("ListasReproduccion");
            modelBuilder.HasKey(lr => lr.ID);
            modelBuilder.Property(lr => lr.Nombre).IsRequired();
            modelBuilder.HasOne(lr => lr.Usuario).WithMany(u => u.ListasReproduccion).HasForeignKey(lr => lr.UsuarioID);
            modelBuilder.HasMany(lr => lr.ListaReproduccionContenido).WithOne(lrc => lrc.ListaReproduccion).HasForeignKey(lrc => lrc.ListaReproduccionID);
        }

    }
}