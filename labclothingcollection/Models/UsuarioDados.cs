using System.ComponentModel.DataAnnotations;

namespace labclothingcollection.Models
{
    public class UsuarioDados
    {
        [MaxLength(255)]
        public string? Nome { get; set; }

        [MaxLength(20)]
        public string? Genero { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "O ano de lançamento deve ser uma data válida.")]
        public DateTime Nascimento { get; set; }

        [MaxLength(20)]
        public string? Telefone { get; set; }

        [MaxLength(20)]
        public string? Tipo { get; set; }
    }
}
