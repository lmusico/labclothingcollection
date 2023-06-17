using System.ComponentModel.DataAnnotations;

namespace labclothingcollection.Models
{
    public class Usuario : Pessoa
    {
        [Required(ErrorMessage ="O campo e-mail é obrigatório")]
        [MaxLength(255)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "O campo de e-mail não é válido.")]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Tipo { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

    }
}
