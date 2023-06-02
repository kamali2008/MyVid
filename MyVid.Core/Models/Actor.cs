using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVid.Core.Models
{
    public class Actor
    {
        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; }

        public virtual ICollection<ContenidoActor> ContenidoActores { get; set; }
    }

}
