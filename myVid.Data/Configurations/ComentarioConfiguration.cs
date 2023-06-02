using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace myVid.Data
{
    internal class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> modelBuilder)
        {
            modelBuilder.ToTable("Comentarios");
            modelBuilder.HasKey(c => c.ID);
            modelBuilder.HasOne(c => c.Contenido).WithMany(co => co.Comentarios).HasForeignKey(c => c.ContenidoID);
            modelBuilder.HasOne(c => c.Usuario).WithMany(u => u.Comentarios).HasForeignKey(c => c.UsuarioID);
            modelBuilder.Property(c => c.ContenidoComentario).IsRequired();
            modelBuilder.Property(c => c.Fecha).IsRequired();
        }

    }
}