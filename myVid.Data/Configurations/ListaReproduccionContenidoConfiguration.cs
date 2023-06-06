using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace MyVid.Data
{
    internal class ListaReproduccionContenidoConfiguration : IEntityTypeConfiguration<ListaReproduccionContenido>
    {
        public void Configure(EntityTypeBuilder<ListaReproduccionContenido> modelBuilder)
        {

            modelBuilder.ToTable("ListaReproduccionContenido");
            modelBuilder.HasKey(lrc => new { lrc.ListaReproduccionID, lrc.ContenidoID });
            modelBuilder.HasOne(lrc => lrc.ListaReproduccion).WithMany(lr => lr.ListaReproduccionContenido).HasForeignKey(lrc => lrc.ListaReproduccionID);
            modelBuilder.HasOne(lrc => lrc.Contenido).WithMany(c => c.ListaReproduccionContenido).HasForeignKey(lrc => lrc.ContenidoID);

        }

    }
}