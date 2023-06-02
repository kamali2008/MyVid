using System.ComponentModel.DataAnnotations.Schema;

namespace MyVid.Core.Models
{
    public class ContenidoActor
    {
        [ForeignKey("Contenido")]
        public int ContenidoID { get; set; }

        public virtual Contenido Contenido { get; set; }

        [ForeignKey("Actor")]
        public int ActorID { get; set; }

        public virtual Actor Actor { get; set; }
    }

}
