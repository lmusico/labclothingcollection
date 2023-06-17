using labclothingcollection.Models;

namespace labclothingcollection
{
    public static class MockUsuarios
    {
        public static IList<Usuario> usuario = new List<Usuario>()
        {
            new Usuario
            {
                Identificador = 1,
                Email = "teste@teste.com",
                Tipo = "Administrador",
                Status = "Ativo",
                Nome = "João da Silva",
                Genero = "masculino",
                Nascimento = new DateTime(1990,10,15),
                Cpf = "365412365",
                Telefone = "9512328"
            },
            new Usuario
            {
                Identificador = 2,
                Email = "exemplo@example.com",
                Tipo = "Gerente",
                Status = "Ativo",
                Nome = "Maria Souza",
                Genero = "feminino",
                Nascimento = new DateTime(1985,05,20),
                Cpf = "874596321",
                Telefone = "987654321"
            },
            new Usuario
            {
                Identificador = 3,
                Email = "usuario@dominio.com",
                Tipo = "Criador",
                Status = "Inativo",
                Nome = "Pedro Santos",
                Genero = "masculino",
                Nascimento = new DateTime(1998,9,5),
                Cpf = "123456789",
                Telefone = "456789123"
            },
            new Usuario {
                Identificador = 4,
                Email = "exemplo2@example.com",
                Tipo = "Outro",
                Status = "Ativo",
                Nome = "Ana Rodrigues",
                Genero = "feminino",
                Nascimento = new DateTime(1987,3,12),
                Cpf = "987654321",
                Telefone = "321654987"
            }

        };
    }
}
