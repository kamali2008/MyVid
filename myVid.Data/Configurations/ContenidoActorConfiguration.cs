using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace MyVid.Data
{
    internal class ContenidoActorConfiguration : IEntityTypeConfiguration<ContenidoActor>
    {
        public void Configure(EntityTypeBuilder<ContenidoActor> modelBuilder)
        {
            modelBuilder.ToTable("ContenidoActores");
            modelBuilder.HasKey(ca => new { ca.ContenidoID, ca.ActorID });
            modelBuilder.HasOne(ca => ca.Contenido).WithMany(c => c.ContenidoActores).HasForeignKey(ca => ca.ContenidoID);
            modelBuilder.HasOne(ca => ca.Actor).WithMany(a => a.ContenidoActores).HasForeignKey(ca => ca.ActorID);
        }

    }
}