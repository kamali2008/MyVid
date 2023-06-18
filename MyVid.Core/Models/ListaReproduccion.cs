using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVid.Core.Models
{
    public class ListaReproduccion
    {
        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; }

        [ForeignKey("Usuario")]
        public string UsuarioID { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<ListaReproduccionContenido> ListaReproduccionContenido { get; set; }
    }

}
