using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVid.Core.Models
{
    public class Usuario : IdentityUser
    {
        public string Nombre { get; set; }
        public virtual ICollection<ListaReproduccion> ListasReproduccion { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Valoracion> Valoraciones { get; set; }

        // Otros relacionamientos
    }

}
