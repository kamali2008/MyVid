using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVid.Core.Models
{
    public class Temporada
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Serie")]
        public int SerieID { get; set; }

        public virtual Serie Serie { get; set; }

        public int Número { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Episodio> Episodios { get; set; }
    }

}
