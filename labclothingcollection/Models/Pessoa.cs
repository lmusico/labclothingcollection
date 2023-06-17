using System.ComponentModel.DataAnnotations;

namespace labclothingcollection.Models
{
    public class Pessoa
    {
        [Key]
        public int Identificador { get; set; }

        [MaxLength(255)]
        public string Nome { get; set; }

        [MaxLength(20)]
        public string Genero { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime, ErrorMessage = "O ano de lançamento deve ser uma data válida.")]
        public DateTime Nascimento { get; set; }

        [MaxLength(14)]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF não é válido.")]
        public string Cpf { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }
    }
}
