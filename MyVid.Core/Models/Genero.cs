using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVid.Core.Models
{
    public class Genero
    {
        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; }

        public virtual ICollection<ContenidoGenero> ContenidoGeneros { get; set; }
    }

}
