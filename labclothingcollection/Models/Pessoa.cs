using System.ComponentModel.DataAnnotations;

namespace labclothingcollection.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public string Nascimento { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Telefone { get; set; }
    }
}
