using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace myVid.Data
{
    internal class IdiomaConfiguration : IEntityTypeConfiguration<Idioma>
    {
        public void Configure(EntityTypeBuilder<Idioma> modelBuilder)
        {
            modelBuilder.ToTable("Idiomas");
            modelBuilder.HasKey(i => i.ID);
            modelBuilder.HasMany(i => i.ContenidoIdiomas).WithOne(ci => ci.Idioma).HasForeignKey(ci => ci.IdiomaID);
        }

    }
}