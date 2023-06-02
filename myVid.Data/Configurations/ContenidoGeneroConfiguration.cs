using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace myVid.Data
{
    internal class ContenidoGeneroConfiguration : IEntityTypeConfiguration<ContenidoGenero>
    {
        public void Configure(EntityTypeBuilder<ContenidoGenero> modelBuilder)
        {
            modelBuilder.ToTable("ContenidoGeneros");
            modelBuilder.HasKey(cg => new { cg.ContenidoID, cg.GeneroID });
            modelBuilder.HasOne(cg => cg.Contenido).WithMany(c => c.ContenidoGeneros).HasForeignKey(cg => cg.ContenidoID);
            modelBuilder.HasOne(cg => cg.Genero).WithMany(g => g.ContenidoGeneros).HasForeignKey(cg => cg.GeneroID);
        }

    }
}