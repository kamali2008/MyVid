using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVid.Core.Models
{
    public class Serie
    {
        [Key]
        [ForeignKey("Contenido")]
        public int ContenidoID { get; set; }
        public virtual Contenido Contenido { get; set; }
        public virtual ICollection<Temporada> Temporadas { get; set; }
    }
}
