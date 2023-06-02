using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVid.Core.Models
{
    public class Idioma
    {
        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; }

        public virtual ICollection<ContenidoIdioma> ContenidoIdiomas { get; set; }
    }

}
