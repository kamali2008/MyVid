using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace MyVid.Data
{
    internal class GeneroConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> modelBuilder)
        {
            modelBuilder.ToTable("Generos");
            modelBuilder.HasKey(g => g.ID);
            modelBuilder.HasMany(g => g.ContenidoGeneros).WithOne(cg => cg.Genero).HasForeignKey(cg => cg.GeneroID);
        }

    }
}