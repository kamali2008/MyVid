using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace MyVid.Data
{
    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> modelBuilder)
        {
            modelBuilder.ToTable("Usuarios");
            modelBuilder.HasKey(u => u.Id);
            modelBuilder.Property(u => u.Nombre).IsRequired();
            modelBuilder.Property(u => u.Email).IsRequired();
            modelBuilder.Property(u => u.PasswordHash).IsRequired();
            modelBuilder.Property(u => u.Rol).IsRequired();
            modelBuilder.HasMany(u => u.ListasReproduccion).WithOne(lr => lr.Usuario).HasForeignKey(lr => lr.UsuarioID);
            modelBuilder.HasMany(u => u.Comentarios).WithOne(c => c.Usuario).HasForeignKey(c => c.UsuarioID);
            modelBuilder.HasMany(u => u.Valoraciones).WithOne(v => v.Usuario).HasForeignKey(v => v.UsuarioID);
        }

    }
}