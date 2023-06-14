using System.ComponentModel.DataAnnotations;

namespace labclothingcollection.Models
{
    public class Usuario : Pessoa
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public bool Status { get; set; }

    }
}
