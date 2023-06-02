using System.ComponentModel.DataAnnotations.Schema;

namespace MyVid.Core.Models
{
    public class ListaReproduccionContenido
    {
        [ForeignKey("ListaReproduccion")]
        public int ListaReproduccionID { get; set; }

        public virtual ListaReproduccion ListaReproduccion { get; set; }

        [ForeignKey("Contenido")]
        public int ContenidoID { get; set; }

        public virtual Contenido Contenido { get; set; }

        public int Orden { get; set; }
    }

}
