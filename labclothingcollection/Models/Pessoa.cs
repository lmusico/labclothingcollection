using System.ComponentModel.DataAnnotations;

namespace labclothingcollection.Models
{
    public class Pessoa
    {
        [Key]
        public int Identificador { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Genero é obrigatório")]
        [MaxLength(20)]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo Nascimento é obrigatório")]
        [MaxLength(10)]
        public string Nascimento { get; set; }

        [Required(ErrorMessage = "O campo Cpf é obrigatório")]
        [MaxLength(14)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório")]
        [MaxLength(20)]
        public string Telefone { get; set; }
    }
}
