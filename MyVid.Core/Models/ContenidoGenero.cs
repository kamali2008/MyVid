using System.ComponentModel.DataAnnotations.Schema;

namespace MyVid.Core.Models
{
    public class ContenidoGenero
    {
        [ForeignKey("Contenido")]
        public int ContenidoID { get; set; }

        public virtual Contenido Contenido { get; set; }

        [ForeignKey("Genero")]
        public int GeneroID { get; set; }

        public virtual Genero Genero { get; set; }
    }

}
