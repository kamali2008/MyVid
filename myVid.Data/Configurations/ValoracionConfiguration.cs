using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace myVid.Data
{
    internal class ValoracionConfiguration : IEntityTypeConfiguration<Valoracion>
    {
        public void Configure(EntityTypeBuilder<Valoracion> modelBuilder)
        {
            modelBuilder.ToTable("Valoraciones");
            modelBuilder.HasKey(v => v.ID);
            modelBuilder.HasOne(v => v.Contenido).WithMany(c => c.Valoraciones).HasForeignKey(v => v.ContenidoID);
            modelBuilder.HasOne(v => v.Usuario).WithMany(u => u.Valoraciones).HasForeignKey(v => v.UsuarioID);
            modelBuilder.Property(v => v.Valor).IsRequired();
            modelBuilder.Property(v => v.Fecha).IsRequired();
        }

    }
}