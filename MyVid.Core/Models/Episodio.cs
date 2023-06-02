using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVid.Core.Models
{
    public class Episodio
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Temporada")]
        public int TemporadaID { get; set; }

        public virtual Temporada Temporada { get; set; }

        public string Título { get; set; }

        public string Descripción { get; set; }

        public int Duración { get; set; }

        public string RutaArchivo { get; set; }
    }

}
