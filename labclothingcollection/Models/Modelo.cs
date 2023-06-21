using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace labclothingcollection.Models
{
    public class Modelo
    {
        [Key]
        public int Identificador { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [ForeignKey("ColecaoId")]
        public int ColecaoId { get; set;}
        public Colecao? Colecao { get; set; }

        [Required]
        [StringLength(20)]
        public string TipoPeca { get; set; }

        [Required]
        [StringLength(20)]
        public string LayoutPeca { get; set; }

    }
}
