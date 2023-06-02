using System.ComponentModel.DataAnnotations.Schema;

namespace MyVid.Core.Models
{
    public class ContenidoIdioma
    {
        [ForeignKey("Contenido")]
        public int ContenidoID { get; set; }

        public virtual Contenido Contenido { get; set; }

        [ForeignKey("Idioma")]
        public int IdiomaID { get; set; }

        public virtual Idioma Idioma { get; set; }
    }

}
