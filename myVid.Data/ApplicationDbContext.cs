using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection;
using MyVid.Core.Models;
using MyVid.Data.Configurations;

namespace MyVid.Data
{


    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contenido> Contenidos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Temporada> Temporadas { get; set; }
        public DbSet<Episodio> Episodios { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<ContenidoActor> ContenidoActores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<ContenidoGenero> ContenidoGeneros { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<ContenidoIdioma> ContenidoIdiomas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ListaReproduccion> ListasReproduccion { get; set; }
        public DbSet<ListaReproduccionContenido> ListasReproduccionContenido { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Valoracion> Valoraciones { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new ActorConfiguration());
            modelBuilder
                .ApplyConfiguration(new ComentarioConfiguration());
            modelBuilder
                .ApplyConfiguration(new ContenidoActorConfiguration());
            modelBuilder
                .ApplyConfiguration(new ContenidoConfiguration());
            modelBuilder
                .ApplyConfiguration(new ContenidoGeneroConfiguration());
            modelBuilder
                .ApplyConfiguration(new ContenidoIdiomaConfiguration());
            modelBuilder
                .ApplyConfiguration(new EpisodioConfiguration());
            modelBuilder
                .ApplyConfiguration(new GeneroConfiguration());
            modelBuilder
                .ApplyConfiguration(new IdiomaConfiguration());
            modelBuilder
                .ApplyConfiguration(new ListaReproduccionConfiguration());
            modelBuilder
                .ApplyConfiguration(new ListaReproduccionContenidoConfiguration());
            modelBuilder
                .ApplyConfiguration(new PeliculaConfiguration());
            modelBuilder
                .ApplyConfiguration(new SerieConfiguration());
            modelBuilder
                .ApplyConfiguration(new TemporadaConfiguration());
            modelBuilder
                .ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder
                .ApplyConfiguration(new ValoracionConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



            // Configuración de eliminación en cascada
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }

            // Configuración de campos obligatorios en base a atributos
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (!property.IsNullable && property.ClrType == typeof(string))
                    {
                        property.SetIsUnicode(false);
                    }
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }

}


