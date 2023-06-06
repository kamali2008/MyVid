using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVid.Core.Models
{
    public class Contenido
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public int Year { get; set; }

        public int? Duracion { get; set; }

        public string Director { get; set; }

        [Required]
        public string Tipo { get; set; }

        public string URLVideo { get; set; }

        public string URLPoster { get; set; }

        //public virtual ICollection<Pelicula> Peliculas { get; set; }

        //public virtual ICollection<Serie> Series { get; set; }

        public virtual ICollection<ContenidoActor> ContenidoActores { get; set; }

        public virtual ICollection<ContenidoGenero> ContenidoGeneros { get; set; }

        public virtual ICollection<ContenidoIdioma> ContenidoIdiomas { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<ListaReproduccionContenido> ListaReproduccionContenido { get; set; }
        public virtual ICollection<Valoracion> Valoraciones { get; set; }

        // Otros relacionamientos
    }

}
