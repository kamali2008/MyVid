using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVid.Core.Models
{
    public class Usuario : IdentityUser<int>
    {
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public virtual ICollection<ListaReproduccion> ListasReproduccion { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Valoracion> Valoraciones { get; set; }

        // Otros relacionamientos
    }

}
