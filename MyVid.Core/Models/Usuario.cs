using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVid.Core.Models
{
    public class Usuario
    {
        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Rol { get; set; }

        public virtual ICollection<ListaReproduccion> ListasReproduccion { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }

        public virtual ICollection<Valoracion> Valoraciones { get; set; }

        // Otros relacionamientos
    }

}
