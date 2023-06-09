using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace MyVid.Data.Configurations
{
    internal class ContenidoConfiguration : IEntityTypeConfiguration<Contenido>
    {
        public void Configure(EntityTypeBuilder<Contenido> modelBuilder)
        {

            modelBuilder.ToTable("Contenidos");
            modelBuilder.HasKey(c => c.ID);
            modelBuilder.Property(c => c.ID).ValueGeneratedOnAdd();
            modelBuilder.Property(c => c.Titulo).IsRequired();
            modelBuilder.Property(c => c.Tipo).IsRequired();
            modelBuilder.HasOne(c => c.Peliculas).WithOne(p => p.Contenido).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.HasOne(c => c.Series).WithOne(s => s.Contenido).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.HasMany(c => c.ContenidoActores).WithOne(ca => ca.Contenido).HasForeignKey(ca => ca.ContenidoID);
            modelBuilder.HasMany(c => c.ContenidoGeneros).WithOne(cg => cg.Contenido).HasForeignKey(cg => cg.ContenidoID);
            modelBuilder.HasMany(c => c.ContenidoIdiomas).WithOne(ci => ci.Contenido).HasForeignKey(ci => ci.ContenidoID);
            
        }
    }
}