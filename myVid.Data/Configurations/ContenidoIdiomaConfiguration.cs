using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace myVid.Data
{
    internal class ContenidoIdiomaConfiguration : IEntityTypeConfiguration<ContenidoIdioma>
    {
        public void Configure(EntityTypeBuilder<ContenidoIdioma> modelBuilder)
        {
            modelBuilder.ToTable("ContenidoIdiomas");
            modelBuilder.HasKey(ci => new { ci.ContenidoID, ci.IdiomaID });
            modelBuilder.HasOne(ci => ci.Contenido).WithMany(c => c.ContenidoIdiomas).HasForeignKey(ci => ci.ContenidoID);
            modelBuilder.HasOne(ci => ci.Idioma).WithMany(i => i.ContenidoIdiomas).HasForeignKey(ci => ci.IdiomaID);
        }

    }
}