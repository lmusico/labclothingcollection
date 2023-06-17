using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace labclothingcollection.Models
{
    public class Colecao
    {
        [Key]
        public int Identificador { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set;}

        [ForeignKey("Usuarios")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuarios { get; set; }

        [Required]
        [StringLength(50)]
        public string Marca { get; set; }

        [Required]
        public decimal Orcamento { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{yyyy}")]
        [DataType(DataType.DateTime, ErrorMessage = "O ano de lançamento deve ser uma data válida.")]
        public DateTime AnoLancamento { get; set; }

        [Required]
        [StringLength(10)]
        public string Estacao { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }

    }
}
