using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVid.Core.Models;

namespace myVid.Data
{
    internal class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> modelBuilder)
        {

            modelBuilder.ToTable("Actores");
            modelBuilder.HasKey(a => a.ID);
            modelBuilder.HasMany(a => a.ContenidoActores).WithOne(ca => ca.Actor).HasForeignKey(ca => ca.ActorID);

        }

    }
}