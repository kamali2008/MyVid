using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVid.Core.Models
{
    public class Comentario
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Contenido")]
        public int ContenidoID { get; set; }

        public virtual Contenido Contenido { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioID { get; set; }

        public virtual Usuario Usuario { get; set; }

        public string ContenidoComentario { get; set; }

        public DateTime Fecha { get; set; }
    }

}
